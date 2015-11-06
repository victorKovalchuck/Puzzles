using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;
using System.Drawing;

namespace Puzzles
{
    public class SetConjunctionBetweenPuzzles
    {
        List<Puzzle> _puzzles;
        FormGameTable _form;
        PictureBox _picture;
        SetSmallPuzzlesLocation setSmallPuzzle = new SetSmallPuzzlesLocation();
        public SetConjunctionBetweenPuzzles(List<Puzzle> puzzles, FormGameTable form,PictureBox picture)
        {
            this._picture = picture;
            this._puzzles = puzzles;
            this._form = form;
        }


        public void SetConnection()
        {
            for (int i = 0; i < _puzzles.Count; i++)
            {
                SetTopPuzzle(_puzzles[i]);
               
            }
            for (int i = 0; i < _puzzles.Count; i++)
            {
                SetBottomPuzzle(_puzzles[i]);

            }
            for (int i = 0; i < _puzzles.Count; i++)
            {
                SetRightPuzzle(_puzzles[i]);

            }
            for (int i = 0; i < _puzzles.Count; i++)
            {
                SetLeftPuzzle(_puzzles[i]);

            }
            
        }

        public void SetLeftPuzzle(Puzzle puzzle)
        {
            List<Puzzle> intersectedPuzzles = _puzzles.Select(x => x.rightPuzzle)
                .Where(x => x.Bounds.IntersectsWith(puzzle.Bounds) && x != puzzle && x.Location.X != 0 && x.Location.Y != 0)
                .ToList();
            puzzle.leftPuzzle = new List<Puzzle>();
            if (intersectedPuzzles.Count != 0)
            {
                for (int i = 0; i < intersectedPuzzles.Count; i++)
                {
                    Puzzle leftPuzzle = new Puzzle();
                    leftPuzzle.Size = new Size(10, 10);
                    leftPuzzle.CoordinateX = intersectedPuzzles[i].Location.X;
                    leftPuzzle.CoordinateY = intersectedPuzzles[i].Location.Y - puzzle.Location.Y;
                    setSmallPuzzle.SetLeftPuzzleLocation(puzzle);
                    leftPuzzle.Image = Image.FromFile(@"..\..\Resources\Background.bmp");                   
                    _form.Controls.Add(leftPuzzle);
                    puzzle.leftPuzzle.Add(leftPuzzle);
                }
            }        
        }

        public void SetBottomPuzzle(Puzzle puzzle)
        {
            var controls = _form.Controls.Cast<Control>();
            List<Puzzle> intersectedPuzzles = controls
                .Where(x => x.Bounds.IntersectsWith(puzzle.Bounds)
                    && x != puzzle && x.GetType() == typeof(Puzzle)).Cast<Puzzle>()
                .ToList();
            puzzle.bottomPuzzle = new List<Puzzle>();

            if (intersectedPuzzles.Count != 0)
            {
                for (int i = 0; i < intersectedPuzzles.Count; i++)
                {
                    Puzzle bottomPuzzle = new Puzzle();
                    bottomPuzzle.Size = new Size(10, 10);
                    bottomPuzzle.CoordinateX = intersectedPuzzles[i].Location.X - puzzle.Location.X;
                    bottomPuzzle.CoordinateY = intersectedPuzzles[i].Location.Y;
                    setSmallPuzzle.SetBottomPuzzleLocation(puzzle);
                    bottomPuzzle.Image = Image.FromFile(@"..\..\Resources\Background.bmp");                   
                    _form.Controls.Add(bottomPuzzle);
                    puzzle.bottomPuzzle.Add(bottomPuzzle);
                }
            }
        }

        private void SetRightPuzzle(Puzzle puzzle)
        {
            puzzle.rightPuzzle = new Puzzle();
            if (puzzle.CoordinateX + puzzle.Width < _picture.Width)
            {
                puzzle.rightPuzzle.Size = new Size(10, 10);
                setSmallPuzzle.SetRightPuzzleLocation(puzzle);
                puzzle.rightPuzzle.Image =GetPartOfImage(new Rectangle(puzzle.CoordinateX + puzzle.Width, puzzle.CoordinateY + puzzle.Height / 2 - 5, 10, 10));          
                _form.Controls.Add(puzzle.rightPuzzle);
            }
        
        }

        private void SetTopPuzzle(Puzzle puzzle)
        {
            puzzle.topPuzzle = new Puzzle();
            if (puzzle.CoordinateY != 0)
            {
                puzzle.topPuzzle.Size = new Size(10, 10);
                setSmallPuzzle.SetTopPuzzleLocation(puzzle);
                puzzle.topPuzzle.Image = GetPartOfImage(new Rectangle(puzzle.CoordinateX + puzzle.Width / 2, puzzle.CoordinateY - 10, 10, 10));          
                _form.Controls.Add(puzzle.topPuzzle);
            }
        }
      

        private Image GetPartOfImage(Rectangle rec)
        {            
            Bitmap sourceBitmap = new Bitmap(_picture.Image);
            Bitmap croppedBitmap = sourceBitmap.Clone(rec, sourceBitmap.PixelFormat);
            return croppedBitmap;
        }
    }
}
