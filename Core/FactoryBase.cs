using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;

namespace Core
{
    public abstract class FactoryBase
    {
        public abstract Puzzle[,] CreateIdenticalSizePuzzles();
        public abstract List<Puzzle> CreateDifferentSizePuzzles(Puzzle[,] puzzles);
     
    }
}
