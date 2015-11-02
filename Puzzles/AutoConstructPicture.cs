using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Utilits;
using System.Windows.Forms;

namespace Puzzles
{
    public class AutoConstructPicture
    {
        Form1 form;
        public AutoConstructPicture(Form1 form1)
        {
            this.form = form1;
        }
        public void Construct(List<Puzzle> puzzles)
        {
            puzzles.Sort();

            foreach (Puzzle puzzle in puzzles)
            {
                Puzzle automatedPuzzle = new Puzzle();
                automatedPuzzle.Location = new System.Drawing.Point(puzzle.CoordinateX + form.Width * 1 / 3, puzzle.CoordinateY + 20);
                automatedPuzzle.Size = new System.Drawing.Size(puzzle.Width, puzzle.Height);
                automatedPuzzle.Image = puzzle.Image;
                automatedPuzzle.BorderStyle = BorderStyle.Fixed3D;
                form.Controls.Add(automatedPuzzle);
            }

        }
    }
}
