using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Core;
using Utilits;

namespace Puzzles
{
    public class ThrowPuzzlesOnDesk
    {
        const int distenseBetweenPuzzles = 20;
        PictureBox _picture;
        Form1 _form1;
        Random rng = new Random();
        SetSmallPuzzlesLocation smallPuzzles = new SetSmallPuzzlesLocation();
        public ThrowPuzzlesOnDesk(Form1 form1, PictureBox picture)
        {
            this._picture = picture;
            this._form1 = form1;
        }

        public List<Puzzle> Throw(List<Puzzle> puzzles)
        {
            List<Puzzle> puzzlesList = RotatePictureBox(puzzles);
            puzzlesList.Shuffle();
            SpillPuzzles(puzzlesList);
            return puzzlesList;
        }

        private void SpillPuzzles(List<Puzzle> puzzles)
        {
            FillBottomSiteByPuzzles(puzzles);           
        }

        private void FillLeftSiteByPuzzles(List<Puzzle> puzzles)
        {
            int controlY = 20;
            int controlX = 20;
            for (int i = 0; i < puzzles.Count; i++)
            {
                if (controlX + puzzles[i].Size.Width + distenseBetweenPuzzles > _form1.Size.Width / 3)
                {
                    controlX = 20;
                    controlY += 140 + distenseBetweenPuzzles;
                    if (controlY + puzzles[i].Size.Height + distenseBetweenPuzzles > _form1.Size.Height * 2 / 3)
                    {
                        break;                        
                    }
                }
                puzzles[i].Location = new Point(controlX, controlY);
                controlX += puzzles[i].Size.Width + distenseBetweenPuzzles;
                _form1.Controls.Add(puzzles[i]);
            }            
        }

        private void FillBottomSiteByPuzzles(List<Puzzle> puzzles)
        {
            int puzzlesAreaY = _form1.Size.Height - _picture.Height + 20; 
            int puzzlesAreaX = 20;
            int buttonsArea = 350;
            List<Puzzle> restOfPuzzles;
            for (int i = 0; i < puzzles.Count; i++)
            {
                if (puzzlesAreaX + puzzles[i].Size.Width + distenseBetweenPuzzles > _form1.Size.Width)
                {
                    puzzlesAreaX = 20;
                    puzzlesAreaY += 140 + distenseBetweenPuzzles;
                }
                //else if (puzzlesAreaX + puzzles[i].Size.Width + distenseBetweenPuzzles + buttonsArea > _form1.Size.Width
                //     && puzzlesAreaY >_form1.Size.Height - _picture.Height + 20)
                //{
                //    restOfPuzzles = puzzles
                //    .Skip(i)
                //    .Take(puzzles.Count)
                //    .ToList();
                //    FillLeftSiteByPuzzles(restOfPuzzles);
                //    break;

                //}
                puzzles[i].Location = new Point(puzzlesAreaX, puzzlesAreaY);
                if (puzzles[i].topPuzzle != null)
                {
                   smallPuzzles.SetTopPuzzleLocation(puzzles[i]);
                }
                if (puzzles[i].rightPuzzle != null)
                {
                    smallPuzzles.SetRightPuzzleLocation(puzzles[i]);
                }
                
                   smallPuzzles.SetBottomPuzzleLocation(puzzles[i]);
                   smallPuzzles.SetLeftPuzzleLocation(puzzles[i]);
                   
                
                puzzlesAreaX += puzzles[i].Size.Width + distenseBetweenPuzzles;
                _form1.Controls.Add(puzzles[i]);
            }
        }


        private List<Puzzle> RotatePictureBox(List<Puzzle> puzzles)
        {
            Array values = Enum.GetValues(typeof(PuzzlesConfigurations.rotateVariants));
            foreach (Puzzle puzzle in puzzles)
            {
                PuzzlesConfigurations.rotateVariants rotateFlip = (PuzzlesConfigurations.rotateVariants)values.GetValue(rng.Next(values.Length));
                switch (rotateFlip)
                {
                    case PuzzlesConfigurations.rotateVariants.Rotate0:
                        break;
                    case PuzzlesConfigurations.rotateVariants.Rotate90:
                        puzzle.Size = new Size(puzzle.Size.Height, puzzle.Size.Width);
                        puzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        puzzle.ImageDegree = 90;
                        if (puzzle.topPuzzle.Image != null)
                        {
                            puzzle.topPuzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                        if (puzzle.rightPuzzle.Image != null)
                        {
                            puzzle.rightPuzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                        break;
                    case PuzzlesConfigurations.rotateVariants.Rotate180:
                        puzzle.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        puzzle.ImageDegree = 180;
                        if (puzzle.topPuzzle.Image != null)
                        {
                            puzzle.topPuzzle.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }
                        if (puzzle.rightPuzzle.Image != null)
                        {
                            puzzle.rightPuzzle.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }
                        break;
                    case PuzzlesConfigurations.rotateVariants.Rotate270:
                        puzzle.Size = new Size(puzzle.Size.Height, puzzle.Size.Width);
                        puzzle.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        puzzle.ImageDegree = 270;
                        if (puzzle.topPuzzle.Image != null)
                        {
                            puzzle.topPuzzle.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        if (puzzle.rightPuzzle.Image != null)
                        {
                            puzzle.rightPuzzle.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        }
                        break;
                }                                        
            }

            return puzzles;
        }       
    }
}
