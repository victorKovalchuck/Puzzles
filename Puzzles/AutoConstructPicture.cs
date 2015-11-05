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
        FormGameTable form;
        SetSmallPuzzlesLocation smallPuzzles = new SetSmallPuzzlesLocation();
        PictureBox _image;
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
                              
                automatedPuzzle.Location = new System.Drawing.Point(puzzle.CoordinateX + form.Width-_image.Width-40, puzzle.CoordinateY + 20);
                automatedPuzzle.Size = new System.Drawing.Size(puzzle.Width, puzzle.Height);
                automatedPuzzle.Width = puzzle.Width;
                automatedPuzzle.Height = puzzle.Height;
                automatedPuzzle.Image = puzzle.Image;
         
                automatedPuzzle.BorderStyle = BorderStyle.Fixed3D;
                automatedPuzzle.BringToFront();
              //  automatedPuzzle.BackColor = Color.Transparent;
                if (puzzle.topPuzzle != null && puzzle.topPuzzle.Image != null)
                {

                    automatedPuzzle.topPuzzle = new Puzzle();                   
                    automatedPuzzle.topPuzzle.Image = puzzle.topPuzzle.Image;
                    automatedPuzzle.topPuzzle.Size = new Size(10, 10);
                    automatedPuzzle.topPuzzle.BorderStyle = BorderStyle.Fixed3D;
                    automatedPuzzle.Parent = automatedPuzzle.topPuzzle;
                    smallPuzzles.SetTopPuzzleLocation(automatedPuzzle);
                    form.Controls.Add(automatedPuzzle.topPuzzle);
                  automatedPuzzle.topPuzzle.BringToFront();
                }
                if (puzzle.rightPuzzle != null && puzzle.rightPuzzle.Image != null)
                {

                    automatedPuzzle.rightPuzzle = new Puzzle();
                    automatedPuzzle.rightPuzzle.Image = puzzle.rightPuzzle.Image;
                    automatedPuzzle.rightPuzzle.Size = new Size(10, 10);
                    automatedPuzzle.rightPuzzle.BorderStyle = BorderStyle.Fixed3D;
                    automatedPuzzle.Parent = automatedPuzzle.rightPuzzle;
                    smallPuzzles.SetRightPuzzleLocation(automatedPuzzle);                   
                    form.Controls.Add(automatedPuzzle.rightPuzzle);
                    automatedPuzzle.rightPuzzle.BringToFront();
                }
                automatedPuzzle.BackColor = Color.Transparent;
                form.Controls.Add(automatedPuzzle);
               
                
                    _image.SendToBack();
                    
                


              
                
               
            }


        }
    }

}
