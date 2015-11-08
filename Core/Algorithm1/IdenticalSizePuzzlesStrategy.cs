using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Drawing;
using Core.Algorithm1.AlgorithmAdditionMethods;

namespace Core.Algorithm1
{
    public class IdenticalSizePuzzlesStrategy : IPuzzlesStrategy
    {
        Image _image;
        Puzzle[,] puzzles = new Puzzle[PuzzlesConfigurations.Vertical, PuzzlesConfigurations.Horizontal];
        ConvertPuzzlesToList puzzlesEnumeration = new ConvertPuzzlesToList();
        public IdenticalSizePuzzlesStrategy(Image image)
        {
            _image = image;
        }
        public List<Puzzle> ExtractPuzzles()
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
            List<Puzzle> puzzlesList = puzzlesEnumeration.Create(puzzles);

            return puzzlesList;
        }
    }
}
