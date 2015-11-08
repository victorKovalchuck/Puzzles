using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Core;
using Core.Algorithm1;
using Utilits;
using System.Drawing;

namespace PuzzlesTest
{
    [TestClass]
    public class CoreTest
    {
    
        PictureBox pictureBox;
        [TestInitialize]
        public void SetPictureBox()
        {

            pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("ImageForTest.jpg");
        }
        [TestMethod]
        public void CreateIdenticalSizePuzzlesTest()
        {
            PuzzlesStrategyFactoryMethod puzzlesStrategy = new PuzzlesStrategyFactoryMethod(pictureBox.Image);
            IPuzzlesStrategy identicalPuzzlesStrategy = puzzlesStrategy.GetStrategy(PuzzlesConfigurations.StrategyTypeEnum.Identical);
            List<Puzzle> puzzles = identicalPuzzlesStrategy.ExtractPuzzles();
            Assert.AreEqual(puzzles[0].Width, puzzles[1].Width);

        }

        [TestMethod]
        public void CreateDifferentSizePuzzlesTest()
        {
            PuzzlesStrategyFactoryMethod puzzlesStrategy = new PuzzlesStrategyFactoryMethod(pictureBox.Image);
            IPuzzlesStrategy differentPuzzlesStrategy = puzzlesStrategy.GetStrategy(PuzzlesConfigurations.StrategyTypeEnum.Different);
            List<Puzzle> puzzles = differentPuzzlesStrategy.ExtractPuzzles();
            foreach (Puzzle puzzle in puzzles)
            {
                if (puzzle.Width != puzzles[0].Width)
                {
                    Assert.AreNotEqual(puzzle.Width, puzzles[0].Width);
                }               
            }
        }
    }
}
