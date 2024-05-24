﻿using System.Text;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Project__Filter
{
    public partial class Opt_Merge : UserControl
    {
        string selectedPath = string.Empty;

        public Opt_Merge()
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

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox_Select.SelectedItem.ToString();
            PopulateFiles(selectedItem);
        }
        private void button_Merge_Click(object sender, EventArgs e)
        {

        }

        //Function
        private void PopulateFiles(string fileType)
        {
            Task.Run(() =>
            {
                List<string> filePaths = new List<string>();

                // Use the Directory class from System.IO to get all files of the specified type recursively
                switch (fileType)
                {
                    case "TEXT":
                        filePaths.AddRange(Directory.GetFiles(selectedPath, "*.txt", SearchOption.AllDirectories));
                        break;
                    case "WORD":
                        filePaths.AddRange(Directory.GetFiles(selectedPath, "*.doc", SearchOption.AllDirectories));
                        filePaths.AddRange(Directory.GetFiles(selectedPath, "*.docx", SearchOption.AllDirectories));
                        break;
                    case "PDF":
                        filePaths.AddRange(Directory.GetFiles(selectedPath, "*.pdf", SearchOption.AllDirectories));
                        break;
                    case "HTML":
                        filePaths.AddRange(Directory.GetFiles(selectedPath, "*.html", SearchOption.AllDirectories));
                        break;
                    default:
                        MessageBox.Show("Invalid selection");
                        return;
                }

                // Run on the UI thread
                Invoke((MethodInvoker)delegate
                {
                    // Clear the ListBox items
                    listBox_File.Items.Clear();

                    // Add the file paths to the ListBox
                    foreach (string filePath in filePaths)
                    {
                        listBox_File.Items.Add(filePath);
                    }

                    // Display the count of files in textBox_Path
                    label_Count.Text = filePaths.Count.ToString();
                });
            });
        }


        private void Text_Files(List<string> filePaths)
        {
            Task.Run(() =>
            {
                using (StreamWriter fileDest = new StreamWriter(Path.Combine(selectedPath, "Merge.txt"), true))
                {
                    int totalFiles = filePaths.Count;
                    int processedFiles = 0;

                    foreach (string filePath in filePaths)
                    {
                        using (StreamReader fileSrc = new StreamReader(filePath))
                        {
                            string line;
                            while ((line = fileSrc.ReadLine()) != null)
                            {
                                fileDest.WriteLine(line);
                            }
                        }

                        // Calculate the progress percentage
                        processedFiles++;
                        int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

                        // Report the progress
                        Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            progressBar_Time.Value = progressPercentage;
                        });
                    }
                }

                // Reset the progress bar to 0 when done
                Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    progressBar_Time.Value = 0;
                });
            });
        }


        private void PDF_Files(List<string> filePaths)
        {
            Task.Run(() =>
            {
                // Create the output file path
                string outputFilePath = Path.Combine(selectedPath, "Merge.pdf");

                // Create a new PDF document
                Document document = new Document();
                PdfCopy copy = new PdfCopy(document, new FileStream(outputFilePath, FileMode.Create));

                // Open the document for writing
                document.Open();

                int totalFiles = filePaths.Count;
                int processedFiles = 0;

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

                    // Calculate the progress percentage
                    processedFiles++;
                    int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

                    // Report the progress
                    Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        progressBar_Time.Value = progressPercentage;
                    });
                }

                // Close the document
                document.Close();

                // Reset the progress bar to 0 when done
                Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    progressBar_Time.Value = 0;
                });
            });
        }

        public void HTML_Files(List<string> filePaths)
        {
            Task.Run(() =>
            {
                HtmlDocument doc = new HtmlDocument();
                HtmlNode bodyNode = doc.CreateElement("body");

                int totalFiles = filePaths.Count;
                int processedFiles = 0;

                foreach (string filePath in filePaths)
                {
                    HtmlDocument fileDoc = new HtmlDocument();
                    fileDoc.Load(filePath);
                    HtmlNode fileBody = fileDoc.DocumentNode.SelectSingleNode("//body");
                    if (fileBody != null)
                    {
                        foreach (HtmlNode child in fileBody.ChildNodes)
                        {
                            bodyNode.AppendChild(child.CloneNode(true));
                        }
                    }

                    // Dispose of the HtmlDocument manually
                    fileDoc = null;

                    // Calculate the progress percentage
                    processedFiles++;
                    int progressPercentage = (int)((double)processedFiles / totalFiles * 100);

                    // Report the progress
                    Invoke((MethodInvoker)delegate
                    {
                        // Running on the UI thread
                        progressBar_Time.Value = progressPercentage;
                    });

                    // Force a garbage collection to free up memory
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                doc.DocumentNode.AppendChild(bodyNode);
                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePaths[0]), "Merged.html");
                File.WriteAllText(outputFilePath, doc.DocumentNode.OuterHtml, Encoding.UTF8);

                // Reset the progress bar to 0 when done
                Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    progressBar_Time.Value = 0;
                });
            });
        }
    }
}
