using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;

namespace Puzzles
{
    public class DropPuzzleNearOther
    {
        Puzzle _droppingPuzzle;
        public DropPuzzleNearOther(Puzzle droppingPuzzle)
        {
            _droppingPuzzle = droppingPuzzle;
        }


        public void PlacePuzzles(List<Puzzle> puzzles)
        {
            GetClosestPuzzle(puzzles);        
        }

        private void GetClosestPuzzle(List<Puzzle> puzzles)
        { 
        
        }
    }
}
