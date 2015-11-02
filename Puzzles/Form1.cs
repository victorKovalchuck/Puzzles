﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puzzles
{
    public partial class Form1 : Form
    {
        RunPuzzlesGame puzzleGame;
        public Form1()
        {
            InitializeComponent();
            InitControlsLocation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.Title = "Please select an image file.";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Location = new Point(this.Size.Width - 400, 20);
                Image img = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = resizeImage(img, new Size(this.pictureBox1.Width, this.pictureBox1.Height));
            }

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            puzzleGame = new RunPuzzlesGame(this, pictureBox1);
            puzzleGame.Start();        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitControlsLocation()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            this.button1.Location = new Point(area.Width - button1.Width - 60, area.Height - 50);
            this.button2.Location = new Point(area.Width - button2.Size.Width - button1.Size.Width - 80, area.Height - 50);
            this.button4.Location = new Point(area.Width - button2.Size.Width - button1.Size.Width*2 - 100, area.Height - 50);
            this.button3.Location = new Point(area.Width - button3.Size.Width, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (puzzleGame != null)
            {
                puzzleGame.BuildPicture();
            }
        }
    }
}
