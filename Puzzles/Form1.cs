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
    public partial class FormGameTable : Form
    {
        const int distanceBetweenControls = 20;
        RunPuzzlesGame puzzleGame;
        Image image;
        bool firstRound=true;

        public FormGameTable()
        {
            InitializeComponent();
            InitControlsLocation();
        }


        private void startGame_Click(object sender, EventArgs e)
        {
            startGame.Visible = false;
            if (puzzleGame != null)
            {
                if (firstRound)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want end this game?", "New Game", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        puzzleGame.DisposePuzzles();
                        puzzleGame = new RunPuzzlesGame(this, mainPicture);
                        puzzleGame.Start();
                        autoConstruct.Enabled = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                    }
                }
                else
                {
                    puzzleGame.DisposePuzzles();
                    puzzleGame = new RunPuzzlesGame(this, mainPicture);
                    puzzleGame.Start();
                    autoConstruct.Enabled = true;
                }
            }
            else
            {
                puzzleGame = new RunPuzzlesGame(this, mainPicture);
                puzzleGame.Start();
                autoConstruct.Enabled = true;
            }
        }


        private void InitControlsLocation()
        {
            Screen myScreens = Screen.FromControl(this);

            this.autoConstruct.Location = new Point(this.Width - autoConstruct.Width - distanceBetweenControls, myScreens.WorkingArea.Height - autoConstruct.Height - distanceBetweenControls);
            mainPicture.Location = new Point(this.Width - mainPicture.Width - distanceBetweenControls, distanceBetweenControls);
            pictureText.Location = new Point(mainPicture.Location.X + (mainPicture.Width - pictureText.Width) / 2, mainPicture.Height / 2);
        }

        private void autoConstruct_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to complete the game using auto construct feature?", "Auto construct", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (puzzleGame != null)
                {
                    puzzleGame.BuildPicture();
                }
                autoConstruct.Enabled = false;           
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void mainPicture_Click(object sender, EventArgs e)
        {
            pictureText.Visible = false;
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.Title = "Please select an image file.";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog1.FileName);
                if (image.Width > 400 || image.Height > 350)
                {
                    image = image.Resize(400, 350);
                }
                mainPicture.Size = GetAliquotImageSize(new System.Drawing.Size(image.Width, image.Height));
                mainPicture.Image = resizeImage(image, mainPicture.Size);
                mainPicture.Location = new Point(this.Size.Width - mainPicture.Size.Width - distanceBetweenControls, distanceBetweenControls);

                startGame.Visible = true; ;
            }

            this.startGame.Location = new Point(mainPicture.Location.X + mainPicture.Width - startGame.Width,
                mainPicture.Location.Y + mainPicture.Height + distanceBetweenControls);
        }

        private Size GetAliquotImageSize(Size size)
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

        private static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public void ChangePicture()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want change picture and end this game ?", "ChangePicture", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {              
                puzzleGame.DisposePuzzles();
                firstRound = false;
                mainPicture_Click(new object(), new EventArgs());
                startGame.Visible = true;
            }
            else if (dialogResult == DialogResult.No)
            {
            }         
        }
    }
}
