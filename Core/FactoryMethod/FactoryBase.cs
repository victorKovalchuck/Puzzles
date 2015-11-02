using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;

namespace Core.FactoryMethod
{
    public abstract class FactoryBase
    {
        public abstract Puzzle[,] CreatePuzzles();
        public abstract List<Puzzle> ModifyPuzzles(Puzzle[,] puzzles);
     
    }
}
