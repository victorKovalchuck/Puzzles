using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilits;
using System.Drawing;

namespace Puzzles
{
    public class CheckForPictureBuildCorrectness
    {
        Form1 _form;
        List<Puzzle> _basePuzzlesList;
        int order;
        int firstPuzzleCoordinateX;
        int firstPuzzleCoordinateY;
        public CheckForPictureBuildCorrectness(Form1 form, List<Puzzle> baseList)
        {
            this._form = form;
            this._basePuzzlesList = baseList;
        }

      
        public bool Check(List<Puzzle> mixedPuzzlesList)
        {          
            var controls = _form.Controls.Cast<Control>();
            Puzzle firstPuzzle = controls
              .Where(x => x.GetType() == typeof(Puzzle))
              .Cast<Puzzle>()
              .Where(x => x.CoordinateX == 0 && x.CoordinateY == 0)
              .FirstOrDefault(); 
            firstPuzzleCoordinateX = firstPuzzle.Location.X;
            firstPuzzleCoordinateY = firstPuzzle.Location.Y;

            for (int i = 0; i < _basePuzzlesList.Count; i++)
            {
                
                int puzzleMiddleX = _basePuzzlesList[i].CoordinateX + firstPuzzleCoordinateX + _basePuzzlesList[i].Width / 2;
                int puzzleMiddleY = _basePuzzlesList[i].CoordinateY + firstPuzzleCoordinateY + _basePuzzlesList[i].Height / 2;
                try
                {
                    Puzzle searchablePuzzle = _form.GetChildAtPoint(new Point(puzzleMiddleX, puzzleMiddleY)) as Puzzle;
                    if (searchablePuzzle.ImageOrder == ++order)
                    {
                        continue;
                    }
                    else
                    {
                        order = 0;
                        return false;                        
                    }

                }
                catch
                {
                    order = 0;
                    return false;
                }
            }
            order = 0;
            return true;
        }


        public void Winner(List<Puzzle> mixedPuzzlesList)           
        {
            foreach (Puzzle puzzle in mixedPuzzlesList)
            {
                puzzle.BorderStyle = BorderStyle.FixedSingle;               
            }
        }
        
    }
}
