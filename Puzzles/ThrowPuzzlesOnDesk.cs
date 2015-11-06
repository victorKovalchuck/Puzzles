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
        const int buttonsArea = 150;
        PictureBox _picture;
        FormGameTable _form1;
        Random rng = new Random();
        int maxSizePuzzle;
        int maxSizeSmallerPuzzle;

        SetSmallPuzzlesLocation smallPuzzles = new SetSmallPuzzlesLocation();
        public ThrowPuzzlesOnDesk(FormGameTable form1, PictureBox picture)
        {
            this._picture = picture;
            this._form1 = form1;
        }

        public List<Puzzle> Throw(List<Puzzle> puzzles)
        {
            List<Puzzle> puzzlesList = RotatePictureBox(puzzles);
            puzzlesList.Shuffle();
            FillBottomSiteBySmallerPuzzles(puzzlesList);
            return puzzlesList;
        }
       

        private void FillBottomSiteBySmallerPuzzles(List<Puzzle> puzzles)
        {
            int puzzlesAreaY = _picture.Location.Y + _picture.Height + 20;
            int puzzlesAreaX = 20;          

            List<Puzzle> smallerPuzzles = GetSmallerPuzzlesSize(puzzles);
            for (int i = 0; i <= smallerPuzzles.Count; i++)
            {
                if (smallerPuzzles.Count == i)
                {
                    List<Puzzle> biggerPuzzles = puzzles.Where(s => smallerPuzzles.All(w => w != s))
                        .ToList();
                    puzzlesAreaX +=  distenseBetweenPuzzles;
                    
                    SetPuzzlesWithBiggerSize(biggerPuzzles, new Point(puzzlesAreaX, puzzlesAreaY));
                    return;
                }
                if (puzzlesAreaX + smallerPuzzles[i].Size.Width > _form1.Size.Width - buttonsArea)
                {
                    puzzlesAreaX = 20;
                    puzzlesAreaY += smallerPuzzles.Select(x => x.Size.Height).Max() + distenseBetweenPuzzles;                  
                }                
          
                smallerPuzzles[i].Location = new Point(puzzlesAreaX, puzzlesAreaY);
                SetSmallPuzzles(smallerPuzzles[i]);


                puzzlesAreaX += smallerPuzzles[i].Size.Width + distenseBetweenPuzzles;
                _form1.Controls.Add(smallerPuzzles[i]);
            }
        }

        private void SetPuzzlesWithBiggerSize(List<Puzzle> puzzles, Point point)
        {
            List<Puzzle> puzzlesUpOnScreen = puzzles.Where(x => x.Size.Height > x.Size.Width).ToList();
            List<Puzzle> puzzlesDownOnScreen = puzzles.Where(x => x.Size.Height < x.Size.Width).ToList();
            SetPuzzleOnTop(puzzlesUpOnScreen);
            SetPuzzleOnBottom(puzzlesDownOnScreen, point);
        }

        private void SetPuzzleOnTop(List<Puzzle> puzzlesUpOfScreen)
        {
            int controlY = 20;
            int controlX = 20;
            for (int i = 0; i < puzzlesUpOfScreen.Count; i++)
            {
                if (controlX + puzzlesUpOfScreen[i].Size.Width + distenseBetweenPuzzles > _form1.Size.Width / 3)
                {
                    controlX = 20;
                    controlY += maxSizePuzzle + distenseBetweenPuzzles;
                   
                }
                puzzlesUpOfScreen[i].Location = new Point(controlX, controlY);
                SetSmallPuzzles(puzzlesUpOfScreen[i]);
                controlX += puzzlesUpOfScreen[i].Size.Width + distenseBetweenPuzzles;
                _form1.Controls.Add(puzzlesUpOfScreen[i]);
            }            
        
        }
        private void SetPuzzleOnBottom(List<Puzzle> puzzlesDownOfScreen, Point point)
        {
            int puzzlesAreaX = point.X;
            int puzzlesAreaY = point.Y;
            for (int i = 0; i < puzzlesDownOfScreen.Count; i++)
            {
                if (puzzlesAreaX + puzzlesDownOfScreen[i].Size.Width > _form1.Size.Width -buttonsArea)
                {
                    puzzlesAreaX = 20;
                    puzzlesAreaY += maxSizeSmallerPuzzle + distenseBetweenPuzzles;
                }
                puzzlesDownOfScreen[i].Location = new Point(puzzlesAreaX, puzzlesAreaY);
                SetSmallPuzzles(puzzlesDownOfScreen[i]);


                puzzlesAreaX += puzzlesDownOfScreen[i].Size.Width + distenseBetweenPuzzles;
                _form1.Controls.Add(puzzlesDownOfScreen[i]);
            }
        }

        private List<Puzzle> GetSmallerPuzzlesSize(List<Puzzle> puzzles)
        {           
  
            int secondMaxPuzzleSize;
            int lessThanMaxWith = puzzles
                .Where(x => x.Size.Width != maxSizePuzzle || x.Size.Height != maxSizePuzzle)
                .Select(x=>x.Size.Width)
                .Max();
            int lessThanMaxHeight = puzzles
                .Where(x => x.Size.Width != maxSizePuzzle || x.Size.Height != maxSizePuzzle)
                .Select(x => x.Size.Height)
                .Max();
            if (lessThanMaxHeight > lessThanMaxWith)
            {
                secondMaxPuzzleSize = lessThanMaxHeight;
            }
            else
            {
                secondMaxPuzzleSize = lessThanMaxWith;
            }
            List<Puzzle> smallerPuzzels = puzzles
                .Where(x => x.Size.Width < secondMaxPuzzleSize && x.Size.Height < secondMaxPuzzleSize)
                .ToList();
            int smallerPuzzleMaxWidth = smallerPuzzels.Select(x => x.Size.Width).Max();
            int smallerPuzzleMaxHeight = smallerPuzzels.Select(x => x.Size.Width).Max();
            if (smallerPuzzleMaxWidth > smallerPuzzleMaxHeight)
            {
                maxSizeSmallerPuzzle = smallerPuzzleMaxWidth;
            }
            else
            {
                maxSizeSmallerPuzzle = smallerPuzzleMaxHeight;
            }
               
            return smallerPuzzels;
        }

        private void SetSmallPuzzles(Puzzle puzzle)
        {
            if (puzzle.topPuzzle != null)
            {
                smallPuzzles.SetTopPuzzleLocation(puzzle);
            }
            if (puzzle.rightPuzzle != null)
            {
                smallPuzzles.SetRightPuzzleLocation(puzzle);
            }
            if (puzzle.bottomPuzzle != null)
            {
                smallPuzzles.SetBottomPuzzleLocation(puzzle);
            }
            if (puzzle.leftPuzzle != null)
            {
                smallPuzzles.SetLeftPuzzleLocation(puzzle);
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


        private void MaxPuzzleSize(List<Puzzle> puzzles)
        {
            int maxWidth = puzzles.Select(x => x.Size.Width).Max();
            int maxHeight = puzzles.Select(x => x.Size.Height).Max();
            if (maxHeight > maxWidth)
            {
                maxSizePuzzle = maxHeight;
            }
            else
            {
                maxSizePuzzle = maxWidth;
            }
        }
    }
}
