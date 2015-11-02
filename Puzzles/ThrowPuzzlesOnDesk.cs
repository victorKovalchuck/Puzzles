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
        const int distenseBetweenPuzzles = 10;
        PictureBox _picture;
        Form1 _form1;
        Random rng = new Random();

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
            int controlY = _form1.Size.Height - _picture.Height + 20; ;
            int controlX = 20;
            List<Puzzle> restOfPuzzles;
            for (int i = 0; i < puzzles.Count; i++)
            {
                if (controlX + puzzles[i].Size.Width + distenseBetweenPuzzles > _form1.Size.Width)
                {
                    controlX = 20;
                    controlY += 140 + distenseBetweenPuzzles;
                    if (controlY + 140 > _form1.Size.Height)
                    {
                        restOfPuzzles = puzzles
                        .Skip(i)
                        .Take(puzzles.Count)
                        .ToList();
                        FillLeftSiteByPuzzles(restOfPuzzles);
                        break;
                    }
                }                
                puzzles[i].Location = new Point(controlX, controlY);
                controlX += puzzles[i].Size.Width + distenseBetweenPuzzles;
                _form1.Controls.Add(puzzles[i]);
            }
        }


        private List<Puzzle> RotatePictureBox(List<Puzzle> puzzles)
        {
            Array values = Enum.GetValues(typeof(PuzzlesStock.rotateVariants));
            foreach (Puzzle puzzle in puzzles)
            {
                PuzzlesStock.rotateVariants rotateFlip = (PuzzlesStock.rotateVariants)values.GetValue(rng.Next(values.Length));
                switch (rotateFlip)
                {
                    case PuzzlesStock.rotateVariants.Rotate90:
                        puzzle.Size = new Size(puzzle.Size.Height, puzzle.Size.Width);
                        puzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        puzzle.ImageDegree = 90;
                        break;
                    case PuzzlesStock.rotateVariants.Rotate180:
                        puzzle.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        puzzle.ImageDegree = 180;
                        break;
                    case PuzzlesStock.rotateVariants.Rotate270:
                        puzzle.Size = new Size(puzzle.Size.Height, puzzle.Size.Width);
                        puzzle.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        puzzle.ImageDegree = 270;
                        break;
                }                                        
            }

            return puzzles;
        }       
    }
}
