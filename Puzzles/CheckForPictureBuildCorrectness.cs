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
    public class CheckForPictureBuildCorrectness
    {
        FormGameTable _form;
        List<Puzzle> _basePuzzlesList;
        Label winnerLabel;
        Label playAgain;
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
                    if (searchablePuzzle != null && searchablePuzzle.Size.Width == 10 && searchablePuzzle.Size.Height == 10)
                    {
                        Puzzle puzzleBehindSmall = controls
                         .Where(x => x.GetType() == typeof(Puzzle))
                         .Cast<Puzzle>()
                         .Where(x => x.Bounds.IntersectsWith(searchablePuzzle.Bounds) && x!=searchablePuzzle)
                         .FirstOrDefault();
                        searchablePuzzle = puzzleBehindSmall;
                    }
                    if (searchablePuzzle != null)
                    {
                        if (searchablePuzzle.ImageOrder == ++order && searchablePuzzle.ImageDegree==0)
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
            WinnerNotes(mixedPuzzlesList);
        }

        private void WinnerNotes(List<Puzzle> mixedPuzzlesList)           
        {
            Puzzle lastXPuzzle=mixedPuzzlesList.Where(p=>mixedPuzzlesList.All(z=>z.Location.X<=p.Location.X)).First();
            winnerLabel = new Label();
            winnerLabel.AutoSize = true;
            winnerLabel.Location = new Point(firstPuzzleCoordinateX + (lastXPuzzle.Location.X + lastXPuzzle.Width - firstPuzzleCoordinateX) / 2 - winnerLabel.Width / 2, 60);
            winnerLabel.Text = "You Win";          
            winnerLabel.Font = new Font(FontFamily.GenericSansSerif, 14);
            winnerLabel.ForeColor = Color.Green;
            _form.Controls.Add(winnerLabel);
            winnerLabel.BringToFront();
            winnerLabel.BackColor = Color.Transparent;
            playAgain = new Label();

            playAgain.AutoSize = true;
            playAgain.Text = "Click on main picture to play again";          
            playAgain.Location = new Point(firstPuzzleCoordinateX + (lastXPuzzle.Location.X + lastXPuzzle.Width - firstPuzzleCoordinateX) / 2 - 115, 90);            
            playAgain.Font = new Font(FontFamily.GenericSansSerif, 10);
            playAgain.ForeColor = Color.Maroon;
            _form.Controls.Add(playAgain);
            playAgain.BringToFront();
            playAgain.BackColor = Color.Transparent;
        }
        public void Dispose()
        {
            if (winnerLabel != null)
            {
                winnerLabel.Dispose();
            }
            if (playAgain != null)
            {
                playAgain.Dispose();
            }
        }
    }
}
