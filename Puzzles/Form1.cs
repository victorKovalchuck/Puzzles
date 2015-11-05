using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puzzles
{
    public partial class FormGameTable : Form
    {
        RunPuzzlesGame puzzleGame;
        Image image;
        public FormGameTable()
        {
            InitializeComponent();
            InitControlsLocation();
        }

        private void loadPicture_Click(object sender, EventArgs e)
        {
           


        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void brakeImage_Click(object sender, EventArgs e)
        {
            puzzleGame = new RunPuzzlesGame(this, pictureBox1);
            puzzleGame.Start();
            buildPicture.Enabled = true;
  
            brakeImage.Enabled = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitControlsLocation()
        {
           
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;

            this.brakeImage.Location = new Point(area.Width - brakeImage.Width - 60, area.Height - 50);
            this.buildPicture.Location = new Point(area.Width - brakeImage.Size.Width - brakeImage.Size.Width - 80, area.Height - 50);
            this.closeButton.Location = new Point(area.Width - closeButton.Size.Width, 0);           
            pictureBox1.Location = new Point(area.Width -400, 20);
            label1.Location = new Point(area.Width - 290, 100);
        

           
         
        }

        private void buildPicture_Click(object sender, EventArgs e)
        {
            if (puzzleGame != null)
            {
                puzzleGame.BuildPicture();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.Title = "Please select an image file.";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                 image = Image.FromFile(openFileDialog1.FileName);
                 if (image.Width > 400 || image.Height > 300)
                 {
                     image = image.Resize(400, 350);                   
                 }
                 pictureBox1.Size = ResizeIm(new System.Drawing.Size(image.Width, image.Height));
                 pictureBox1.Image = resizeImage(image, pictureBox1.Size);
                 pictureBox1.Location = new Point(this.Size.Width - pictureBox1.Size.Width - 40, 20);
             
                brakeImage.Enabled = true;
            }
        }

        private Size ResizeIm(Size size)
        {
            while (size.Width % 5 != 0)
            {
                size.Width--;
            
            }
            while (size.Height % 7 != 0)
            {
                size.Height--;
            }
            return size;
        }
    }
}
