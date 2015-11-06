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
        FormGameTable _form;
        List<Puzzle> _basePuzzlesList;
        int order;
        int firstPuzzleCoordinateX;
        int firstPuzzleCoordinateY;
        public CheckForPictureBuildCorrectness(FormGameTable form, List<Puzzle> baseList)
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
              .Where(x => x.ImageOrder == 1)
              .FirstOrDefault();
            if (firstPuzzle!=null)
            {
                firstPuzzleCoordinateX = firstPuzzle.Location.X;
                firstPuzzleCoordinateY = firstPuzzle.Location.Y;

                for (int i = 0; i < _basePuzzlesList.Count; i++)
                {

                    int puzzleMiddleX = _basePuzzlesList[i].CoordinateX + firstPuzzleCoordinateX + _basePuzzlesList[i].Width / 2;
                    int puzzleMiddleY = _basePuzzlesList[i].CoordinateY + firstPuzzleCoordinateY + _basePuzzlesList[i].Height / 2;

                    Puzzle searchablePuzzle = _form.GetChildAtPoint(new Point(puzzleMiddleX, puzzleMiddleY)) as Puzzle;
                    if (searchablePuzzle != null)
                    {
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

                    else
                    {
                        order = 0;
                        return false;
                    }
                }
                order = 0;
                return true;
            }
            return false;
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
