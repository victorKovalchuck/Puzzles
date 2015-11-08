using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using Core.Algorithm1.AlgorithmAdditionMethods;
using System.Drawing;

namespace Core.Algorithm1
{
    public class DifferentSizePuzzlesStrategy : IPuzzlesStrategy
    {
        SetDifferentPuzzles setPuzzle = new SetDifferentPuzzles();
        ConvertPuzzlesToList puzzlesEnumeration = new ConvertPuzzlesToList();
        Image _image;
        Puzzle[,] puzzles = new Puzzle[PuzzlesConfigurations.Vertical, PuzzlesConfigurations.Horizontal];
        public DifferentSizePuzzlesStrategy(Image image)
        {
            _image = image;
        }  
        public List<Puzzle> ExtractPuzzles()
        {
            Puzzle[,] puzzlesIdentical = IdenticalPuzzles(puzzles);
            for (int y = 0; y < PuzzlesConfigurations.Vertical; y++)
            {
                for (int x = 0; x < PuzzlesConfigurations.Horizontal; x++)
                {
                    if (puzzlesIdentical[y, x] != null && !puzzlesIdentical[y, x].Changed)
                    {
                        setPuzzle.SetBrakeCouplePuzzle(y, x, puzzlesIdentical);
                    }
                }
            }
            List<Puzzle> puzzlesList = puzzlesEnumeration.Create(puzzlesIdentical);

            return puzzlesList;
        }

        private Puzzle[,] IdenticalPuzzles(Puzzle[,] puzzles)
        {
            for (int y = 0; y < PuzzlesConfigurations.Vertical; y++)
            {
                for (int x = 0; x < PuzzlesConfigurations.Horizontal; x++)
                {
                    Puzzle puzzle = new Puzzle();
                    puzzle.Width = _image.Width / PuzzlesConfigurations.Horizontal;
                    puzzle.Height = _image.Height / PuzzlesConfigurations.Vertical;
                    puzzle.CoordinateX = puzzle.Width * x;
                    puzzle.CoordinateY = puzzle.Height * y;
                    puzzles[y, x] = puzzle;
                }
            }

            return puzzles;
        }
    }
}
