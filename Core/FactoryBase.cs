using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;
using System.Drawing;

namespace Core
{
    public abstract class FactoryBase
    {
        public abstract Puzzle[,] CreateIdenticalSizePuzzles(Image image);
        public abstract List<Puzzle> CreateDifferentSizePuzzles(Puzzle[,] puzzles);
     
    }
}
