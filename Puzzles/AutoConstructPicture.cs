using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Utilits;
using System.Windows.Forms;
using System.Drawing;

namespace Puzzles
{
    public class AutoConstructPicture
    {
        const int distanseBetweenControls = 30;
        FormGameTable form;
        SetSmallPuzzlesLocation smallPuzzles = new SetSmallPuzzlesLocation();
        PictureBox _image;
        List<Puzzle> automatedConstructPuzzlesList=new List<Puzzle>();
        public AutoConstructPicture(FormGameTable form1, PictureBox image)
        {
            this.form = form1;
            _image = image;
        }
        public void Construct(List<Puzzle> puzzles)
        {
            puzzles.Sort();
            foreach (Puzzle puzzle in puzzles)
            {
                Puzzle automatedPuzzle = new Puzzle();
                automatedPuzzle.Location = new System.Drawing.Point(puzzle.CoordinateX + form.Width - _image.Width - distanseBetweenControls, puzzle.CoordinateY + distanseBetweenControls);
                automatedPuzzle.Size = new System.Drawing.Size(puzzle.Width, puzzle.Height);
                automatedPuzzle.Width = puzzle.Width;
                automatedPuzzle.Height = puzzle.Height;
                automatedPuzzle.Image = puzzle.Image;         
                automatedPuzzle.BorderStyle = BorderStyle.Fixed3D;            
                automatedPuzzle.Click += new EventHandler(automatedPuzzle_Click);
              
                if (puzzle.topPuzzle != null && puzzle.topPuzzle.Image != null)
                {
                   automatedPuzzle.topPuzzle= SetPuzzle(automatedPuzzle.topPuzzle);
                    automatedPuzzle.topPuzzle.Image = puzzle.topPuzzle.Image;
                    smallPuzzles.SetTopPuzzleLocation(automatedPuzzle);                                     
                  
                }
                if (puzzle.rightPuzzle != null && puzzle.rightPuzzle.Image != null)
                {
                    automatedPuzzle.rightPuzzle = SetPuzzle(automatedPuzzle.rightPuzzle);
                    automatedPuzzle.rightPuzzle.Image = puzzle.rightPuzzle.Image;                         
                    smallPuzzles.SetRightPuzzleLocation(automatedPuzzle);                   
                   
                }              
                form.Controls.Add(automatedPuzzle);
                automatedConstructPuzzlesList.Add(automatedPuzzle);
                _image.SendToBack();                                                                     
            }
        }

        Puzzle SetPuzzle(Puzzle puzzle)
        {
            puzzle = new Puzzle();

            puzzle.Size = new Size(10, 10);
            puzzle.BorderStyle = BorderStyle.Fixed3D;         
            form.Controls.Add(puzzle);
            puzzle.BringToFront();
            return puzzle;
        }

        void automatedPuzzle_Click(object sender, EventArgs e)
        {           
            form.ChangePicture();          
        }

        public void DisposePuzzles()
        {
            foreach (Puzzle puzzle in automatedConstructPuzzlesList)
            {
                if (puzzle.bottomPuzzle != null)
                {
                    foreach (Puzzle bottomPuzzle in puzzle.bottomPuzzle)
                    {
                        bottomPuzzle.Dispose();
                    }
                }
                if (puzzle.leftPuzzle != null)
                {
                    foreach (Puzzle leftPuzzle in puzzle.leftPuzzle)
                    {
                        leftPuzzle.Dispose();
                    }
                }
                if (puzzle.topPuzzle != null)
                {
                    puzzle.topPuzzle.Dispose();
                }
                if (puzzle.rightPuzzle != null)
                {
                    puzzle.rightPuzzle.Dispose();
                }
                puzzle.Dispose();
            }
        }
    }

}
