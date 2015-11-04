using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilits;

namespace Puzzles
{
    public class SetSmallPuzzlesLocation
    {
        public void SetTopPuzzleLocation(Puzzle puzzle)
        {
            Point point = new Point();
            if (puzzle.ImageDegree == 0)
            {
                point = new Point(puzzle.Location.X + puzzle.Width / 2, puzzle.Location.Y - 10);
            }
            else if (puzzle.ImageDegree == 90)
            {
                point = new Point(puzzle.Location.X + puzzle.Size.Width, puzzle.Location.Y + puzzle.Size.Height / 2);
            }
            else if (puzzle.ImageDegree == 180)
            {
                point = new Point(puzzle.Location.X + puzzle.Width / 2 - 10, puzzle.Location.Y + puzzle.Size.Height);
            }
            else
            {
                point = new Point(puzzle.Location.X - 10, puzzle.Location.Y + puzzle.Size.Height / 2 - 10);
            }

            puzzle.topPuzzle.Location = point;
        }

        public void SetRightPuzzleLocation(Puzzle puzzle)
        {
            Point point = new Point();
            if (puzzle.ImageDegree == 0)
            {
                point = new Point(puzzle.Location.X + puzzle.Size.Width,
                    puzzle.Location.Y + puzzle.Size.Height / 2 - 5);
            }
            else if (puzzle.ImageDegree == 90)
            {
                point = new Point(puzzle.Location.X + puzzle.Size.Width / 2 - 5,
                    puzzle.Location.Y + puzzle.Size.Height);
            }
            else if (puzzle.ImageDegree == 180)
            {
                point = new Point(puzzle.Location.X - 10, puzzle.Location.Y + puzzle.Size.Height / 2 - 5);
            }
            else
            {
                point = new Point(puzzle.Location.X + puzzle.Size.Width / 2 - 5, puzzle.Location.Y - 10);
            }

            puzzle.rightPuzzle.Location = point;
        }

        public void SetBottomPuzzleLocation(Puzzle puzzle)
        {
            for (int j = 0; j < puzzle.bottomPuzzle.Count; j++)
            {
                Point point = new Point();
                if (puzzle.ImageDegree == 0)
                {
                    point = new Point(puzzle.bottomPuzzle[j].CoordinateX + puzzle.Location.X,
                    puzzle.Location.Y + puzzle.Height - 10);

                }
                else if (puzzle.ImageDegree == 90)
                {
                    point = new Point(puzzle.Location.X,
                     puzzle.Location.Y + puzzle.bottomPuzzle[j].CoordinateX);

                }
                else if (puzzle.ImageDegree == 180)
                {
                    point = new Point(puzzle.Location.X + puzzle.Width - puzzle.bottomPuzzle[j].CoordinateX-10,
                        puzzle.Location.Y);
                }
                else
                {
                    point = new Point(puzzle.Location.X + puzzle.Height - 10,
                           puzzle.Location.Y + puzzle.Width - 10 - puzzle.bottomPuzzle[j].CoordinateX);
                }
                puzzle.bottomPuzzle[j].Location = point;
            }
        }

        public void SetLeftPuzzleLocation(Puzzle puzzle)
        {

            for (int j = 0; j < puzzle.leftPuzzle.Count; j++)
            {
                Point point = new Point();
                if (puzzle.ImageDegree == 0)
                {
                    point = new Point(puzzle.Location.X,
                        puzzle.Location.Y + puzzle.leftPuzzle[j].CoordinateY);

                }
                else if (puzzle.ImageDegree == 90)
                {
                    point = new Point(puzzle.Location.X + puzzle.Size.Width - puzzle.leftPuzzle[j].CoordinateY - 10,
                        puzzle.Location.Y);

                }
                else if (puzzle.ImageDegree == 180)
                {
                    point = new Point(puzzle.Location.X + puzzle.Size.Width - 10,
                        puzzle.Location.Y + puzzle.Size.Height - puzzle.leftPuzzle[j].CoordinateY-10);
                }
                else
                {
                    point = new Point(puzzle.Location.X+puzzle.leftPuzzle[j].CoordinateY,
                        puzzle.Location.Y + puzzle.Size.Height - 10);
                }
                puzzle.leftPuzzle[j].Location = point;
            }
        
        }

    }
}