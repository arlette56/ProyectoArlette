using System;
using System.Windows.Forms;

namespace ProyectoArlette.Formas
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FormaImagenes : Form
    {
        private float zoomFactor = 1.0f;
        private Image originalImage;
        private Point cropStart;
        private Rectangle cropRectangle;
        private bool isCropping;

        public FormaImagenes()
        {
            InitializeComponent();
            originalImage = pictureBox1.Image; 
            isCropping = false;
            cropStart = Point.Empty;
            cropRectangle = new Rectangle();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                originalImage = pictureBox1.Image; 
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (zoomFactor > 0.1f)
            {
                zoomFactor -= 0.1f;
                ApplyZoom();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zoomFactor += 0.1f;
            ApplyZoom();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void ApplyZoom()
        {
            if (originalImage != null)
            {
                int newWidth = (int)(originalImage.Width * zoomFactor);
                int newHeight = (int)(originalImage.Height * zoomFactor);
                pictureBox1.Image = new Bitmap(originalImage, newWidth, newHeight);
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent; 
        }

        private void loadGifButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos GIF|*.gif|Todos los archivos|*.*";
                openFileDialog.Title = "Selecciona un archivo GIF";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string gifPath = openFileDialog.FileName;

                    try
                    {
                        pictureBox1.Image = Image.FromFile(gifPath);
                        originalImage = pictureBox1.Image; 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar el archivo GIF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap texturedBitmap = ApplyTexture(originalBitmap);
                pictureBox1.Image = texturedBitmap;
            }
        }

        private Bitmap ApplyTexture(Bitmap original)
        {
            int textureSize = 5; 
            Bitmap texturedImage = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y += textureSize)
            {
                for (int x = 0; x < original.Width; x += textureSize)
                {
                    Color textureColor = original.GetPixel(x, y);

                    for (int i = 0; i < textureSize; i++)
                    {
                        for (int j = 0; j < textureSize; j++)
                        {
                            int newX = x + i;
                            int newY = y + j;

                            if (newX < original.Width && newY < original.Height)
                            {
                                texturedImage.SetPixel(newX, newY, textureColor);
                            }
                        }
                    }
                }
            }

            return texturedImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);
                Bitmap rotatedBitmap = RotateImage(originalBitmap, 90); 
                pictureBox1.Image = rotatedBitmap;
            }
        }

        private Bitmap RotateImage(Bitmap original, float angle)
        {
            Bitmap rotatedImage = new Bitmap(original.Width, original.Height);

            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                graphics.TranslateTransform(original.Width / 2, original.Height / 2);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-original.Width / 2, -original.Height / 2);
                graphics.DrawImage(original, new Point(0, 0));
            }

            return rotatedImage;
        }

        private void cropButton_Click(object sender, EventArgs e)
        {
            isCropping = !isCropping;
            if (isCropping)
            {
                cropButton.Text = "Finalizar Recorte";
                pictureBox1.MouseDown += PictureBox1_MouseDown;
                pictureBox1.MouseUp += PictureBox1_MouseUp;
                pictureBox1.Paint += PictureBox1_Paint;
            }
            else
            {
                cropButton.Text = "Recortar";
                pictureBox1.MouseDown -= PictureBox1_MouseDown;
                pictureBox1.MouseUp -= PictureBox1_MouseUp;
                pictureBox1.Paint -= PictureBox1_Paint;
                if (pictureBox1.Image != null)
                {
                    CropImage();
                }
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCropping)
            {
                cropStart = e.Location;
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isCropping)
            {
                cropRectangle = new Rectangle(cropStart.X, cropStart.Y, e.X - cropStart.X, e.Y - cropStart.Y);
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isCropping)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, cropRectangle);
                }
            }
        }

        private void CropImage()
        {
            if (cropRectangle.Width > 0 && cropRectangle.Height > 0)
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap originalBitmap = new Bitmap(pictureBox1.Image);

                    
                    cropRectangle.X = Math.Max(0, cropRectangle.X);
                    cropRectangle.Y = Math.Max(0, cropRectangle.Y);
                    cropRectangle.Width = Math.Min(cropRectangle.Width, originalBitmap.Width - cropRectangle.X);
                    cropRectangle.Height = Math.Min(cropRectangle.Height, originalBitmap.Height - cropRectangle.Y);

                    Bitmap croppedBitmap = new Bitmap(cropRectangle.Width, cropRectangle.Height);

                    using (Graphics graphics = Graphics.FromImage(croppedBitmap))
                    {
                        graphics.DrawImage(originalBitmap, new Rectangle(0, 0, cropRectangle.Width, cropRectangle.Height), cropRectangle, GraphicsUnit.Pixel);
                    }

                    pictureBox1.Image = croppedBitmap;
                }
            }
        }
    }
}
    

    


    





