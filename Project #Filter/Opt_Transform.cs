using System.Data;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfSharp.Drawing;
using ImageMagick;

namespace Project__Filter
{
    public partial class Opt_Transform : UserControl
    {
        string selectedPath;

        public Opt_Transform()
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

                // Define the file extensions for each case
                List<string> fileExtensions = new List<string>();
                switch (selectedItem)
                {
                    case "IMAGE To PDF (TITLE)":
                        radioButton_Custom.Enabled = true;
                        radioButton_Folder.Enabled = true;
                        checkBox_Name.Enabled = true;
                        checkBox_Date.Enabled = true;
                        checkBox_Size.Enabled = true;
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
                        break;
                    case "IMAGE To PDF (NO TITLE)":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = true;
                        checkBox_Date.Enabled = true;
                        checkBox_Size.Enabled = true;
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
                        break;
                    case "IMAGE To ICO":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "bmp", "gif", "svg" };
                        break;
                    case "IMAGE To WEBP":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "bmp", "gif", "svg", "tiff" };
                        break;
                    case "IMAGE To BMP":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "jpg", "jpeg", "png", "bmp", "gif", "svg", "tiff", "webp" };
                        break;
                    case "IMAGE To ASCII":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "jpg", "jpeg", "png" };
                        break;
                    case "VIDEO To AUDIO":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "mp4", "avi", "mkv", "flv", "mov", "wmv" };
                        break;
                    case "VIDEO To WEBM":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "mp4", "avi", "mkv", "flv", "mov", "wmv", "m4v", "mpeg", "mpg" };
                        break;
                    case "VIDEO To AVI":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "mp4", "mkv", "flv", "mov", "wmv", "m4v", "mpeg", "mpg" };
                        break;
                    case "AUDIO To WAV":
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        fileExtensions = new List<string> { "mp3", "aac", "flac", "m4a", "ogg", "wma", "mpeg", "mpg" };
                        break;
                    default:
                        listBox_File.Items.Clear();
                        radioButton_Custom.Enabled = false;
                        radioButton_Folder.Enabled = false;
                        checkBox_Name.Enabled = false;
                        checkBox_Date.Enabled = false;
                        checkBox_Size.Enabled = false;
                        break;

                }

                // Get all image files in the selected directory that can be converted to the selected format
                string[] imageFiles = Directory.EnumerateFiles(selectedPath)
                                               .Where(file => fileExtensions.Any(ext => file.ToLower().EndsWith(ext)))
                                               .ToArray();

                listBox_File.Items.Clear();

                foreach (string imageFile in imageFiles)
                {
                    listBox_File.Items.Add(Path.GetFileName(imageFile));
                }
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
                        CreatedPDF();
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
                    case "VIDEO To GIF":
                        VideoGif();
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
            Task.Run(() =>
            {
                if (radioButton_Custom.Checked)
                {
                    // Get all image files in the selected directory and its subdirectories
                    List<string> imageFiles = Directory.EnumerateFiles(selectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png"))
                        .ToList();

                    if (checkBox_Name.Checked)
                    {
                        // Order files by name
                        imageFiles.Sort();
                    }
                    else if (checkBox_Size.Checked)
                    {
                        // Order files by size
                        imageFiles = imageFiles.OrderBy(file => new FileInfo(file).Length).ToList();
                    }
                    else if (checkBox_Date.Checked)
                    {
                        // Order files by date
                        imageFiles = imageFiles.OrderBy(file => new FileInfo(file).CreationTime).ToList();
                    }

                    string Title = Microsoft.VisualBasic.Interaction.InputBox("Enter the title for:", "Title Text", "Default", -1, -1);

                    string pdfPath = Path.Combine(selectedPath, $"{Title}.pdf");

                    // Create a Document object
                    Document document = new Document();

                    // Create a PdfWriter object
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));

                    // Open the Document
                    document.Open();

                    // Add a title page
                    document.NewPage();
                    for (int i = 0; i < 20; i++) // Adjust this value to move the title up or down
                    {
                        document.Add(new Paragraph("\n"));
                    }
                    Paragraph title = new Paragraph(Title, FontFactory.GetFont(FontFactory.HELVETICA, 50f, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    for (int i = 0; i < 10; i++) // Adjust this value to move the title up or down
                    {
                        document.Add(new Paragraph("\n"));
                    }

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
                    // Get the name of the folder that the file is in
                    string folderName = new DirectoryInfo(selectedPath).Name;

                    string pdfPath = Path.Combine(selectedPath, $"{folderName}.pdf");

                    // Create a Document object
                    Document document = new Document();

                    // Create a PdfWriter object
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));

                    // Open the Document
                    document.Open();

                    // Add a title page
                    document.NewPage();
                    for (int i = 0; i < 20; i++) // Adjust this value to move the title up or down
                    {
                        document.Add(new Paragraph("\n"));
                    }
                    Paragraph title = new Paragraph(folderName, FontFactory.GetFont(FontFactory.HELVETICA, 50f, iTextSharp.text.Font.BOLD)); // Increase the font size here
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    for (int i = 0; i < 10; i++) // Adjust this value to move the title up or down
                    {
                        document.Add(new Paragraph("\n"));
                    }
                    // Get all image files in the selected directory and its subdirectories
                    List<string> imageFiles = Directory.EnumerateFiles(selectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png"))
                        .ToList();

                    if (checkBox_Name.Checked)
                    {
                        // Order files by name
                        imageFiles.Sort();
                    }
                    else if (checkBox_Size.Checked)
                    {
                        // Order files by size
                        imageFiles = imageFiles.OrderBy(file => new FileInfo(file).Length).ToList();
                    }
                    else if (checkBox_Date.Checked)
                    {
                        // Order files by date
                        imageFiles = imageFiles.OrderBy(file => new FileInfo(file).CreationTime).ToList();
                    }

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
                else
                {
                    MessageBox.Show("No radio button is checked.");
                }
            });
        }

        private void PDFNoTitle()
        {
            Task.Run(() =>
            {
                // Get all image files in the selected directory and its subdirectories
                List<string> imageFiles = Directory.EnumerateFiles(selectedPath, "*.*", SearchOption.AllDirectories)
                    .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("jpeg") || file.ToLower().EndsWith("png"))
                    .ToList();

                if (checkBox_Name.Checked)
                {
                    // Order files by name
                    imageFiles.Sort();
                }
                else if (checkBox_Size.Checked)
                {
                    // Order files by size
                    imageFiles = imageFiles.OrderBy(file => new FileInfo(file).Length).ToList();
                }
                else if (checkBox_Date.Checked)
                {
                    // Order files by date
                    imageFiles = imageFiles.OrderBy(file => new FileInfo(file).CreationTime).ToList();
                }

                string pdfPath = Path.Combine(selectedPath, $"Notitle.pdf");

                // Create a PdfDocument object
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

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
            });
        }

        private void ImageIcon()
        {
            Task.Run(() =>
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
            });
        }

        private void ImageWebp()
        {
            Task.Run(() =>
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
            });
        }

        private void ImageBMP()
        {
            Task.Run(() =>
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
            });
        }

        private void ImageAscii()
        {
            Task.Run(() =>
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
            });
        }

        private void VideoAudio()
        {
            Task.Run(() =>
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
            });
        }

        private void VideoWebm()
        {
            Task.Run(() =>
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
            });
        }

        private void VideoAvi()
        {
            Task.Run(() =>
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
            });
        }

        private async Task VideoGif()
        {
            await Task.Run(() =>
            {
                string selectedVideo = listBox_File.SelectedItem.ToString();

                // Create the full path to the video file
                string videoPath = Path.Combine(selectedPath, selectedVideo);

                // Get the duration of the video
                var ffProbe = new NReco.VideoInfo.FFProbe();
                var videoInfo = ffProbe.GetMediaInfo(videoPath);
                double videoDuration = videoInfo.Duration.TotalSeconds;

                // Check if the video is 15 seconds or less
                if (videoDuration <= 15)
                {
                    // Create the full path to the output GIF
                    string gifPath = Path.Combine(selectedPath, Path.GetFileNameWithoutExtension(selectedVideo) + ".gif");

                    // Initialize the converter
                    var converter = new NReco.VideoConverter.FFMpegConverter();

                    // Convert the video to a GIF
                    converter.ConvertMedia(videoPath, gifPath, NReco.VideoConverter.Format.gif);
                }
                else
                {
                    // Show a message box with the error
                    MessageBox.Show("The video is longer than 15 seconds and cannot be converted to a GIF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void AudioWav()
        {
            Task.Run(() =>
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
            });
        }


        private void CreatedPDF()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Create a FolderBrowserDialog to request the path of the folder containing the images.
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select the folder containing the images";
            folderBrowserDialog1.ShowDialog();

            // If the folder path is not an empty string, get all image files in the folder.
            if (folderBrowserDialog1.SelectedPath != "")
            {
                string[] imageFiles = Directory.EnumerateFiles(folderBrowserDialog1.SelectedPath)
                    .Where(file => file.ToLower().EndsWith("jpg") || file.ToLower().EndsWith("png"))
                    .ToArray();

                // Create a PDF document
                PdfSharp.Pdf.PdfDocument doc = new PdfSharp.Pdf.PdfDocument();

                // Add an image to each page of the PDF document
                foreach (string imageFile in imageFiles)
                {
                    PdfSharp.Pdf.PdfPage page = doc.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    using (XImage image = XImage.FromFile(imageFile))
                    {
                        // Get the size of the PDF page
                        double pageWidth = page.Width;
                        double pageHeight = page.Height;

                        // Get the size of the image
                        double imageWidth = image.PixelWidth;
                        double imageHeight = image.PixelHeight;

                        // Calculate the scaling factor to fit the image within the page
                        double scale = Math.Min(pageWidth / imageWidth, pageHeight / imageHeight);

                        // Calculate the new size of the image
                        double scaledImageWidth = imageWidth * scale;
                        double scaledImageHeight = imageHeight * scale;

                        // Draw the image centered on the page
                        gfx.DrawImage(image, (pageWidth - scaledImageWidth) / 2, (pageHeight - scaledImageHeight) / 2, scaledImageWidth, scaledImageHeight);
                    }


                }

                // Save and close the PDF document
                string pdfFileName = Path.Combine(folderBrowserDialog1.SelectedPath, "images.pdf");
                doc.Save(pdfFileName);
                doc.Close();

                // Ask before deleting the images from the selected folder
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete all images?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string imageFile in imageFiles)
                    {
                        File.Delete(imageFile);
                    }
                    MessageBox.Show($"Done! Successfully moved {imageFiles.Length} images to {pdfFileName} and deleted them.");
                }
                else
                {
                    MessageBox.Show($"Done! Successfully moved {imageFiles.Length} images to {pdfFileName}. The images were not deleted.");
                }
            }
        }

    }
}


