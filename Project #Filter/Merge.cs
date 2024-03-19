using DocumentFormat.OpenXml.Packaging;
using iTextSharp.text.pdf;

namespace Project__Filter
{
    public partial class Merge : UserControl
    {
        string selectedPath;

        public Merge()
        {
            InitializeComponent();
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedPath = fbd.SelectedPath;
                    textBox_Path.Text = selectedPath;
                    comboBox_Select.Enabled = true;
                    button_Merge.Enabled = true;
                }
            }
        }

        private void button_Merge_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (var item in listBox_File.SelectedItems)
            {
                selectedItems.Add(item.ToString());
            }

            if (!string.IsNullOrEmpty(selectedPath))
            {
                string selectedItem = comboBox_Select.SelectedItem.ToString();

                switch (selectedItem)
                {
                    case "TEXT":
                        Text_Files(selectedItems);
                        break;
                    case "WORD":
                        Word_Files(selectedItems);
                        break;
                    case "PDF":
                        PDF_Files(selectedItems);
                        break;
                    default:
                        MessageBox.Show("Invalid selection");
                        break;
                }
                if (checkBox_Delete.Checked)
                {

                }
            }
            else
            {
                MessageBox.Show("Path not selected");
            }
        }

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "TEXT":
                    Text_Populated();
                    break;
                case "WORD":
                    Word_Populated();
                    break;
                case "PDF":
                    PDF_Populated();
                    break;
                default:
                    MessageBox.Show("Invalid selection");
                    break;
            }
        }

        private void Text_Populated()
        {
            listBox_File.Items.Clear();

            List<string> filePaths = new List<string>();

            // Use the Directory class from System.IO to get all text files recursively
            filePaths.AddRange(Directory.GetFiles(selectedPath, "*.txt", SearchOption.AllDirectories));

            // Add the file paths to the ListBox
            foreach (string filePath in filePaths)
            {
                listBox_File.Items.Add(filePath);
            }
        }

        private void Word_Populated()
        {
            listBox_File.Items.Clear();

            List<string> filePaths = new List<string>();

            // Use the Directory class from System.IO to get all Word files recursively
            filePaths.AddRange(Directory.GetFiles(selectedPath, "*.doc", SearchOption.AllDirectories));
            filePaths.AddRange(Directory.GetFiles(selectedPath, "*.docx", SearchOption.AllDirectories));

            // Add the file paths to the ListBox
            foreach (string filePath in filePaths)
            {
                listBox_File.Items.Add(filePath);
            }
        }

        private void PDF_Populated()
        {
            listBox_File.Items.Clear();

            List<string> filePaths = new List<string>();

            // Use the Directory class from System.IO to get all PDF files recursively
            filePaths.AddRange(Directory.GetFiles(selectedPath, "*.pdf", SearchOption.AllDirectories));

            // Add the file paths to the ListBox
            foreach (string filePath in filePaths)
            {
                listBox_File.Items.Add(filePath);
            }
        }

        private void Text_Files(List<string> filePaths)
        {
            using (StreamWriter fileDest = new StreamWriter(Path.Combine(selectedPath, "Merge.txt"), true))
            {
                foreach (string filePath in filePaths)
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        fileDest.WriteLine(line);
                    }
                }
            }
        }

        public void Word_Files(List<string> filePaths)
        {
            // Get the directory of the first file in the list
            string directory = Path.GetDirectoryName(filePaths[0]);

            // Create the output file path
            string outputFilePath = Path.Combine(directory, "Merged.docx");

            using (WordprocessingDocument myDoc = WordprocessingDocument.Create(outputFilePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = myDoc.AddMainDocumentPart();

                foreach (string file in filePaths)
                {
                    using (WordprocessingDocument myWordDoc = WordprocessingDocument.Open(file, true))
                    {
                        DocumentFormat.OpenXml.Wordprocessing.Body body = myWordDoc.MainDocumentPart.Document.Body;

                        foreach (var element in body.Elements())
                        {
                            mainPart.Document.Body.Append(element.CloneNode(true));
                        }
                    }
                }

                mainPart.Document.Save();
            }
        }

        private void PDF_Files(List<string> filePaths)
        {
            // Create a new PDF document
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            // Create a new PdfCopy using the document and a new FileStream for the output PDF
            PdfCopy copy = new PdfCopy(document, new FileStream(Path.Combine(selectedPath, "Merge.pdf"), FileMode.Create));

            // Open the document for writing
            document.Open();

            foreach (string filePath in filePaths)
            {
                // Create a new PdfReader for the current document
                PdfReader reader = new PdfReader(filePath);
                // Add each page from the reader to the PdfCopy
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    copy.AddPage(copy.GetImportedPage(reader, i));
                }
                // Close the reader
                reader.Close();
            }

            // Close the document
            document.Close();
        }
    }
}
