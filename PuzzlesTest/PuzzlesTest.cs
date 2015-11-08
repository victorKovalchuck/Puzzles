using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzles;
using System.Windows.Forms;
using Core;
using Core.Algorithm1;
using Utilits;
using System.Drawing;

namespace PuzzlesTest
{
    [TestClass]
    public class PuzzlesTest
    {
        PictureBox pictureBox;
        FormGameTable formGameTable;
        List<Puzzle> puzzles;

        [TestInitialize]
        public void SetBasicControls()
        {
            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("ImageForTest.jpg");
            puzzles = new List<Puzzle>();
            formGameTable = new FormGameTable();
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Puzzle puzzle = new Puzzle();
                    puzzle.Width = pictureBox.Image.Width / 5;
                    puzzle.Height = pictureBox.Image.Height / 7;                  
                    puzzle.CoordinateX = puzzle.Width * x;
                    puzzle.CoordinateY = puzzle.Height * y;
                    puzzle.Location = new Point(puzzle.CoordinateX, puzzle.CoordinateY);
                    puzzle.ImageOrder = +1;
                    puzzles.Add(puzzle);
                    formGameTable.Controls.Add(puzzle);
                }
            }
        }        

        [TestMethod]
        public void SetConjunctionBetweenPuzzlesTest()
        {
            SetConjunctionBetweenPuzzles smallPuzzles = new SetConjunctionBetweenPuzzles(puzzles, formGameTable, pictureBox);
            smallPuzzles.SetConnection();
            Assert.IsNotNull(puzzles[0].rightPuzzle);
        }

        [TestMethod]
        public void SetSmallPuzzlesLocationTest()
        {
            SetSmallPuzzlesLocation setSmallPuzzles = new SetSmallPuzzlesLocation();        
            puzzles[0].rightPuzzle = new Puzzle();
            setSmallPuzzles.SetRightPuzzleLocation(puzzles[0]);
            Puzzle rightPuzzle = puzzles[0].rightPuzzle;
            Assert.AreEqual(rightPuzzle.Location.X, puzzles[0].Location.X + puzzles[0].Size.Width);
        }


        [TestMethod]
        public void ThrowPuzzlesOnDeskTest()
        {
            ThrowPuzzlesOnDesk throwPuzzles = new ThrowPuzzlesOnDesk(formGameTable, pictureBox);
            List<Puzzle> puzzlesInDifferentLocation = throwPuzzles.Throw(puzzles);
            Assert.AreNotEqual(puzzlesInDifferentLocation[0].Location.X, 0);
        }

        [TestMethod]
        public void AutoConstructPictureTest()
        {
            AutoConstructPicture autoConstruct = new AutoConstructPicture(formGameTable, pictureBox);
            var controls = formGameTable.Controls.Cast<Control>();
            autoConstruct.Construct(puzzles);

            List<Puzzle> puzzlesAfterConstruction = controls
              .Where(x => x.GetType() == typeof(Puzzle))
              .Cast<Puzzle>()
             .ToList();
            Assert.AreEqual(puzzlesAfterConstruction.Count, puzzles.Count * 2);
        }

       
    }
}
