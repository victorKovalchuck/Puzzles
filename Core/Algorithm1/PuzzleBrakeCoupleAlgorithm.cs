using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;
using System.Drawing;
using Core.Algorithm1.AlgorithmAdditionMethods;
using Core;

namespace Core.Algorithm1
{
    public class PuzzleBrakeCoupleAlgorithm:FactoryBase
    {      
        SetDifferentPuzzles setPuzzle = new SetDifferentPuzzles();
        ConvertPuzzlesToList puzzlesEnumeration = new ConvertPuzzlesToList();

        public override Puzzle[,] CreateIdenticalSizePuzzles(Image image)
        {
            Puzzle[,] puzzles = new Puzzle[7, 5];
            
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Puzzle puzzle = new Puzzle();
                    puzzle.Width = image.Width / 5;
                    puzzle.Height = image.Height / 7;
                    puzzle.CoordinateX = puzzle.Width * x;
                    puzzle.CoordinateY = puzzle.Height * y;                                       
                    puzzles[y, x] = puzzle;
                }
            }

            return puzzles;
        }

        public override List<Puzzle> CreateDifferentSizePuzzles(Puzzle[,] puzzles)
        {
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (puzzles[y, x] != null && !puzzles[y, x].Changed)
                    {
                        setPuzzle.SetBrakeCouplePuzzle(y, x, puzzles);
                    }
                }
            }
          
            List<Puzzle> puzzlesList = puzzlesEnumeration.Create(puzzles);

            return puzzlesList;
        }       
    }
}
