using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Drawing;

namespace Core.Algorithm1
{
    public interface IPuzzlesStrategy
    {
        List<Puzzle> ExtractPuzzles();
    }
}
