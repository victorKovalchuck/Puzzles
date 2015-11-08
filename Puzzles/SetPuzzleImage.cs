using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilits;
using System.Drawing;
using Core;

namespace Puzzles
{
    public class SetPuzzleImage
    {
        PictureBox _picture;
        public SetPuzzleImage(PictureBox picture)
        {
            this._picture = picture;
        }
        public List<Puzzle> SetImage(List<Puzzle> puzzles)
        {            
            foreach (Puzzle puzzle in puzzles)
            {
                puzzle.Size = new System.Drawing.Size(puzzle.Width, puzzle.Height);
                puzzle.Location = new System.Drawing.Point(puzzle.CoordinateX, puzzle.CoordinateY);               
                puzzle.Image = GetPartOfImage(new Rectangle(puzzle.CoordinateX, puzzle.CoordinateY, puzzle.Width, puzzle.Height));                
            }            
            return puzzles;
        }
        
        private Image GetPartOfImage(Rectangle rec)
        {
            Bitmap sourceBitmap = new Bitmap(_picture.Image);
            Bitmap croppedBitmap = sourceBitmap.Clone(rec, sourceBitmap.PixelFormat);
            return croppedBitmap;
        }
    }
}
