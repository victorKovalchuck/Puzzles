﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Utilits;

namespace Core.FactoryMethod.Algorithm1.AlgorithmAdditionMethods
{
   public class EnumeratePuzzles
    {
       List<Puzzle> puzzlesList = new List<Puzzle>();
       int order;

       public List<Puzzle> Create(Puzzle[,] puzzles)
       {
           for (int y = 0; y < 7; y++)
           {
               for (int x = 0; x < 5; x++)
               {
                   if (puzzles[y, x] != null)
                   {
                       if (puzzles[y, x].divededPuzzles[0] != null)
                       {
                           for (int i = 0; i < 2; i++)
                           {
                               puzzles[y, x].divededPuzzles[i].ImageOrder = ++order;
                               puzzlesList.Add(puzzles[y, x].divededPuzzles[i]);
                           }
                       }
                       else
                       {
                           puzzles[y, x].ImageOrder = ++order;
                           puzzlesList.Add(puzzles[y, x]);
                       }
                   }
               }
           }

           return puzzlesList;
       }
    }
}