using System.Data;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfSharp.Drawing;
using ImageMagick;

namespace Project__Filter
{
    public partial class Convert : UserControl
    {
        string selectedPath;

        public Convert()
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
                    radioButton_Custom.Enabled = true;
                    radioButton_Folder.Enabled = true;
                    button_Convert.Enabled = true;
                }
            }
        }

        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedPath))
            {
                ComboBox comboBox = sender as ComboBox;

                // Get the selected item
                string selectedItem = comboBox.SelectedItem.ToString();

                switch (selectedItem)
                {
                    case "IMAGE To PDF (TITLE)":
                        radioButton_Custom.Enabled = true;
                        radioButton_Folder.Enabled = true;
                        // Get all image files in the selected directory that can be converted to PDF
                        string[] imageFilesTitle = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("tiff") || file.ToLower().EndsWith("bmp"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string imageFile in imageFilesTitle)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    case "IMAGE To PDF (NO TITLE)":
                        // Get all image files in the selected directory that can be converted to PDF
                        string[] imageFilesNotitle = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("tiff") || file.ToLower().EndsWith("bmp"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string imageFile in imageFilesNotitle)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    case "IMAGE To ICO":
                        // Get all image files in the selected directory that can be converted to ICO
                        string[] imageFilesIco = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("bmp") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("svg"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string imageFile in imageFilesIco)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    case "IMAGE To WEBP":
                        // Get all image files in the selected directory that can be converted to WEBP
                        string[] imageFilesWEBP = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("bmp") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("tiff") || file.ToLower().EndsWith("ico"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string imageFile in imageFilesWEBP)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    case "IMAGE To BMP":
                        // Get all image files in the selected directory that can be converted to BMP
                        string[] imageFilesBmp = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png") || file.ToLower().EndsWith("gif") || file.ToLower().EndsWith("tiff") || file.ToLower().EndsWith("ico") || file.ToLower().EndsWith("webp"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string imageFile in imageFilesBmp)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    case "IMAGE To ASCII":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;

                        string[] imageFilesAscii = Directory.EnumerateFiles(selectedPath)
                                                       .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png"))
                                                       .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string imageFile in imageFilesAscii)
                        {
                            listBox_File.Items.Add(Path.GetFileName(imageFile));
                        }
                        break;
                    case "VIDEO To AUDIO":
                        // Get all video files in the selected directory
                        string[] videoFilestoAudio = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("avi")
                                                        || file.ToLower().EndsWith("mkv") || file.ToLower().EndsWith("flv")
                                                        || file.ToLower().EndsWith("mov") || file.ToLower().EndsWith("wmv"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string videoFile in videoFilestoAudio)
                        {
                            listBox_File.Items.Add(Path.GetFileName(videoFile));
                        }
                        break;
                    case "VIDEO To WEBM":
                        // Get all video files in the selected directory that can be converted to WebM
                        string[] videoFilestoWebm = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("avi")
                                                        || file.ToLower().EndsWith("mkv") || file.ToLower().EndsWith("flv") ||
                                                        file.ToLower().EndsWith("mov") || file.ToLower().EndsWith("wmv") ||
                                                        file.ToLower().EndsWith("m4v") || file.ToLower().EndsWith("mpeg") ||
                                                        file.ToLower().EndsWith("mpg"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string videoFile in videoFilestoWebm)
                        {
                            listBox_File.Items.Add(Path.GetFileName(videoFile));
                        }
                        break;
                    case "VIDEO To AVI":
                        // Get all video files in the selected directory that can be converted to AVI
                        string[] videoFiles = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("mkv") || file.ToLower().EndsWith("flv") || file.ToLower().EndsWith("mov") || file.ToLower().EndsWith("wmv") || file.ToLower().EndsWith("m4v") || file.ToLower().EndsWith("mpeg") || file.ToLower().EndsWith("mpg"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string videoFile in videoFiles)
                        {
                            listBox_File.Items.Add(Path.GetFileName(videoFile));
                        }
                        break;
                    case "AUDIO To WAV":
                        // Get all audio files in the selected directory that can be converted to WAV
                        string[] audioFiles = Directory.EnumerateFiles(selectedPath)
                                                        .Where(file => file.ToLower().EndsWith("mp3") || file.ToLower().EndsWith("aac") || file.ToLower().EndsWith("flac") || file.ToLower().EndsWith("m4a") || file.ToLower().EndsWith("ogg") || file.ToLower().EndsWith("wma"))
                                                        .ToArray();

                        listBox_File.Items.Clear();

                        foreach (string audioFile in audioFiles)
                        {
                            listBox_File.Items.Add(Path.GetFileName(audioFile));
                        }
                        break;
                    default:
                        listBox_File.Items.Clear();
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Path not selected");
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedPath))
            {
                // Get the selected item
                string selectedItem = comboBox_Select.SelectedItem.ToString();

                switch (selectedItem)
                {
                    case "IMAGE To PDF (TITLE)":
                        PDFTitle();
                        break;
                    case "IMAGE To PDF (NO TITLE)":
                        PDFNoTitle();
                        break;
                    case "IMAGE To ICO":
                        ImageIcon();
                        break;
                    case "IMAGE To WEBP":
                        ImageWebp();
                        break;
                    case "IMAGE To BMP":
                        ImageBMP();
                        break;
                    case "IMAGE To ASCII":
                        ImageAscii();
                        break;
                    case "VIDEO To AUDIO":
                        VideoAudio();
                        break;
                    case "VIDEO To WEBM":
                        VideoWebm();
                        break;
                    case "VIDEO To AVI":
                        VideoAvi();
                        break;
                    case "AUDIO To WAV":
                        AudioWav();
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


        private void PDFTitle()
        {
            if (radioButton_Custom.Checked)
            {
                string Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the title for:", "Title Text", "Default", -1, -1);

                string pdfPath = Path.Combine(selectedPath, $"{Title}.pdf");

                // Create a Document object
                Document document = new Document();

                // Create a PdfWriter object
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));

                // Open the Document
                document.Open();

                string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                     .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png"))
                                    .ToArray();

                foreach (string imageFile in imageFiles)
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFile);

                    // Set the page size to the image size
                    document.SetPageSize(new iTextSharp.text.Rectangle(0, 0, image.Width, image.Height));

                    // Add a new page
                    document.NewPage();

                    // Add the image to the document
                    document.Add(image);
                }

                // Close the Document
                document.Close();

                MessageBox.Show($"PDF created successfully at: {pdfPath}");
            }
            else if (radioButton_Folder.Checked)
            {

            }

            else
            {
                MessageBox.Show("No radio button is checked.");
            }
        }

        private void PDFNoTitle()
        {
            string pdfPath = Path.Combine(selectedPath, $"Notitle.pdf");

            // Create a PdfDocument object
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

            string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                             .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png"))
                                             .ToArray();

            foreach (string imageFile in imageFiles)
            {
                XImage image = XImage.FromFile(imageFile);

                // Create a new page with the dimensions of the image
                PdfSharp.Pdf.PdfPage page = document.AddPage();
                page.Width = image.PointWidth;
                page.Height = image.PointHeight;

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Draw the image to fit the page
                gfx.DrawImage(image, 0, 0, page.Width, page.Height);
            }

            // Save the document
            document.Save(pdfPath);

            MessageBox.Show($"PDF created successfully at: {pdfPath}");
        }

        private void ImageIcon()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Load the image file
            using (Bitmap bitmap = new Bitmap(imagePath))
            {
                // Get an Hicon for the Bitmap
                IntPtr hIcon = bitmap.GetHicon();

                // Create a new icon from the handle
                Icon icon = Icon.FromHandle(hIcon);

                // Create the full path to the ICO file
                string icoPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(imagePath) + ".ico");

                // Write the Icon to a File Stream
                using (FileStream fs = new FileStream(icoPath, FileMode.OpenOrCreate))
                {
                    icon.Save(fs);
                }

                MessageBox.Show($"ICO created successfully at: {icoPath}");
            }
        }

        private void ImageWebp()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Create the full path to the WEBP file
            string webpPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(imagePath) + ".webp");

            // Load the image file
            using (MagickImage image = new MagickImage(imagePath))
            {
                // Convert the image to WEBP and save it
                image.Format = MagickFormat.WebP;
                image.Write(webpPath);
            }

            MessageBox.Show($"WEBP created successfully at: {webpPath}");
        }

        private void ImageBMP()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Create the full path to the BMP file
            string bmpPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(imagePath) + ".bmp");

            // Load the image file
            using (MagickImage image = new MagickImage(imagePath))
            {
                // Convert the image to BMP and save it
                image.Format = MagickFormat.Bmp;
                image.Write(bmpPath);
            }

            MessageBox.Show($"BMP created successfully at: {bmpPath}");
        }

        private void ImageAscii()
        {
            // Get the selected image file
            string selectedImage = listBox_File.SelectedItem.ToString();

            // Create the full path to the image file
            string imagePath = Path.Combine(selectedPath, selectedImage);

            // Load the image file
            Bitmap originalImage = new Bitmap(imagePath);

            // Resize the image to 150x100
            Bitmap image = new Bitmap(originalImage, new Size(150, 100));

            // Define the ASCII characters for the index
            string asciiChars = " .:-=+*#%@";

            StringBuilder asciiArt = new StringBuilder();

            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    // Get the pixel color at (w, h)
                    Color pixelColor = image.GetPixel(w, h);

                    // Calculate the grayscale value
                    int grayScale = (int)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);

                    // Convert the grayscale value back into a color
                    Color color = Color.FromArgb(grayScale, grayScale, grayScale);

                    // Calculate the index for the ASCII characters
                    int index = grayScale * 10 / 255;

                    // Append the ASCII character to the ASCII art
                    asciiArt.Append(asciiChars[index]);
                }

                // Append a new line after each row
                asciiArt.Append("\n");
            }

            // Write the ASCII art to a text file
            string asciiArtPath = Path.Combine(selectedPath, "asciiArt_" + Path.GetFileNameWithoutExtension(selectedImage) + ".txt");
            System.IO.File.WriteAllText(asciiArtPath, asciiArt.ToString());

            MessageBox.Show($"ASCII art created successfully at: {asciiArtPath}");
        }

        private void VideoAudio()
        {
            // Get the selected video file
            string selectedVideo = listBox_File.SelectedItem.ToString();

            // Create the full path to the video file
            string videoPath = Path.Combine(selectedPath, selectedVideo);

            // Define the output path for the MP3
            string mp3Path = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(selectedVideo) + ".mp3");

            // Create a new instance of the converter
            var converter = new NReco.VideoConverter.FFMpegConverter();

            // Convert the video to an MP3
            converter.ConvertMedia(videoPath, mp3Path, "mp3");

            MessageBox.Show($"MP3 created successfully at: {mp3Path}");
        }

        private void VideoWebm()
        {
            // Get the selected video file
            string selectedVideo = listBox_File.SelectedItem.ToString();

            // Create the full path to the video file
            string videoPath = Path.Combine(selectedPath, selectedVideo);

            // Define the output path for the WebM
            string webmPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(selectedVideo) + ".webm");

            // Create a new instance of the converter
            var converter = new NReco.VideoConverter.FFMpegConverter();

            // Convert the video to a WebM
            converter.ConvertMedia(videoPath, webmPath, "webm");

            MessageBox.Show($"WebM created successfully at: {webmPath}");
        }

        private void VideoAvi()
        {
            // Get the selected video file
            string selectedVideo = listBox_File.SelectedItem.ToString();

            // Create the full path to the video file
            string videoPath = Path.Combine(selectedPath, selectedVideo);

            // Define the output path for the AVI
            string aviPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(selectedVideo) + ".avi");

            // Create a new instance of the converter
            var converter = new NReco.VideoConverter.FFMpegConverter();

            // Convert the video to an AVI
            converter.ConvertMedia(videoPath, aviPath, "avi");

            MessageBox.Show($"AVI created successfully at: {aviPath}");
        }

        private void AudioWav()
        {
            // Get the selected audio file
            string selectedAudio = listBox_File.SelectedItem.ToString();

            // Create the full path to the audio file
            string audioPath = Path.Combine(selectedPath, selectedAudio);

            // Define the output path for the WAV
            string wavPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(selectedAudio) + ".wav");

            // Create a new instance of the converter
            var converter = new NReco.VideoConverter.FFMpegConverter();

            // Convert the audio to a WAV
            converter.ConvertMedia(audioPath, wavPath, "wav");

            MessageBox.Show($"WAV created successfully at: {wavPath}");
        }
    }
}


