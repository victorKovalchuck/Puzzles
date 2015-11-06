using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Reflection;
using System.IO;
using Core.Algorithm1;
using Utilits;
using System.Windows.Forms;

namespace PuzzlesTest
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void PuzzleBrakeCoupleAlgorithmTest()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile(@"C:\Users\RAZOR\Desktop\Puzzles\Puzzles\Resources\Background.bmp");           
            PuzzleBrakeCoupleAlgorithm puzzleAlgorithm = new PuzzleBrakeCoupleAlgorithm();
            Puzzle[,] sameSizesPuzzles = puzzleAlgorithm.CreateIdenticalSizePuzzles(pictureBox.Image);
            Assert.AreEqual(40, sameSizesPuzzles[0, 0].Width);
           
        }
    }
}
