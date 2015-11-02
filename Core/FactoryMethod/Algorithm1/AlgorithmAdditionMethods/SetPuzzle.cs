using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Utilits;

namespace Core.FactoryMethod.Algorithm1.AlgorithmAdditionMethods
{
    public class SetPuzzle
    {
        Random random = new Random();
        public void SetBrakeCouplePuzzle(int y, int x, Puzzle[,] puzzles)
        {
            if (!puzzles[y, x].Changed)
            {
                Array values = Enum.GetValues(typeof(PuzzlesStock.puzzleChimera));
                PuzzlesStock.puzzleChimera puzzleChimera = (PuzzlesStock.puzzleChimera)values.GetValue(random.Next(values.Length));
                switch (puzzleChimera)
                {
                    case PuzzlesStock.puzzleChimera.horizontalDivide:
                        HorizontalDivide(y, x, puzzles);
                        break;
                    case PuzzlesStock.puzzleChimera.untouchable:
                        Untouchable(y, x, puzzles);
                        break;
                    case PuzzlesStock.puzzleChimera.verticalCouple:
                        VerticalCouple(y, x, puzzles);
                        break;
                    case PuzzlesStock.puzzleChimera.horizontalCouple:
                        HorizontalCouple(y, x, puzzles);
                        break;
                    case PuzzlesStock.puzzleChimera.verticalDivide:
                        VerticalDivide(y, x, puzzles);
                        break;
                    default:
                        break;
                }
            }
        }

        private void VerticalDivide(int y, int x, Puzzle[,] puzzles)
        {
            puzzles[y, x].Changed = true;
            puzzles[y, x].divededPuzzles = new Puzzle[2] { new Puzzle(), new Puzzle() };
            for (int i = 0; i < 2; i++)
            {
                puzzles[y, x].divededPuzzles[i].Width = puzzles[y, x].Width / 2;
                puzzles[y, x].divededPuzzles[i].CoordinateY = puzzles[y, x].CoordinateY;
                if (i == 0)
                {
                    puzzles[y, x].divededPuzzles[i].Changed = true;
                    puzzles[y, x].divededPuzzles[i].CoordinateX = puzzles[y, x].CoordinateX;
                }
                else
                {
                    puzzles[y, x].divededPuzzles[i].Changed = true;
                    puzzles[y, x].divededPuzzles[i].CoordinateX = puzzles[y, x].CoordinateX + puzzles[y, x].Width / 2;
                }
            }
        }

        private void HorizontalCouple(int y, int x, Puzzle[,] puzzles)
        {
            if (x != puzzles.GetLength(1) - 1 && puzzles[y, x + 1] != null)
            {
                puzzles[y, x].Changed = true;
                puzzles[y, x].Width *= 2;                
                puzzles[y, x + 1] = null;
            }
        }

        private void Untouchable(int y, int x, Puzzle[,] puzzles)
        {
            puzzles[y, x].Changed = true;
        }

        private void VerticalCouple(int y, int x, Puzzle[,] puzzles)
        {
            if (y != puzzles.GetLength(0) - 1)
            {
                puzzles[y, x].Changed = true;
                puzzles[y, x].Height *= 2;                
                puzzles[y + 1, x] = null;
            }
        }

        private void HorizontalDivide(int y, int x, Puzzle[,] puzzles)
        {
            puzzles[y, x].Changed = true;
            puzzles[y, x].divededPuzzles = new Puzzle[2] { new Puzzle(), new Puzzle() };
            for (int i = 0; i < 2; i++)
            {
                puzzles[y, x].divededPuzzles[i].Height = puzzles[y, x].Height / 2;
                puzzles[y, x].divededPuzzles[i].CoordinateX = puzzles[y, x].CoordinateX;
                if (i == 0)
                {
                    puzzles[y, x].divededPuzzles[i].Changed = true;
                    puzzles[y, x].divededPuzzles[i].CoordinateY = puzzles[y, x].CoordinateY;
                }
                else
                {
                    puzzles[y, x].divededPuzzles[i].Changed = true;
                    puzzles[y, x].divededPuzzles[i].CoordinateY = puzzles[y, x].CoordinateY + puzzles[y, x].Height / 2;
                }
            }
        }
    }
}
