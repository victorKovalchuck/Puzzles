using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilits;
using System.Windows.Forms;
using System.Drawing;

namespace Puzzles
{
    public class PuzzleEventHandlers
    {
        Form1 _form;
        List<Puzzle> _basePuzzleList;
        List<Puzzle> _mixedPuzzleList;
        SetSmallPuzzlesLocation smallPuzzles = new SetSmallPuzzlesLocation();
        public PuzzleEventHandlers(Form1 form, List<Puzzle> basePuzzleList, List<Puzzle> mixedPuzzleList)
        {
            _form = form;
            _basePuzzleList = basePuzzleList;
            _mixedPuzzleList = mixedPuzzleList;
        }

        public void SetHandlers(List<Puzzle> puzzles)
        {
            foreach (Puzzle puzzle in puzzles)
            {
                _form.DragEnter += new DragEventHandler(_form_DragEnter);
                _form.DragDrop += new DragEventHandler(_form_DragDrop);
                puzzle.DragDrop += new System.Windows.Forms.DragEventHandler(puzzle_DragDrop);
                puzzle.DragEnter += new System.Windows.Forms.DragEventHandler(puzzle_DragEnter);
                puzzle.MouseDown += new MouseEventHandler(puzzle_MouseDown);
                puzzle.GiveFeedback += new GiveFeedbackEventHandler(puzzle_GiveFeedback);
                puzzle.DragOver += new DragEventHandler(puzzle_DragOver);
                puzzle.SendToBack();

                ((Control)puzzle).AllowDrop = true;
            }

        }

        void puzzle_DragOver(object sender, DragEventArgs e)
        {

        }


        void puzzle_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Puzzle puzzle = (Puzzle)sender;
         
            Point relativePoint = _form.PointToClient(Cursor.Position);
            puzzle.Location = new Point(relativePoint.X - puzzle.Size.Width / 2, relativePoint.Y - puzzle.Size.Height / 2);
            puzzle.topPuzzle.AllowDrop = true;
            smallPuzzles.SetTopPuzzleLocation(puzzle);
            smallPuzzles.SetBottomPuzzleLocation(puzzle);
            smallPuzzles.SetRightPuzzleLocation(puzzle);
            smallPuzzles.SetLeftPuzzleLocation(puzzle);
            puzzle.Refresh();
           
         //   puzzle.topPuzzle.BringToFront();
          //  puzzle.bottomPuzzle.BringToFront();
         


        }


        void _form_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void _form_DragDrop(object sender, DragEventArgs e)
        {
            Puzzle puzzle = e.Data.GetData(typeof(Puzzle)) as Puzzle;
            puzzle.Location = _form.PointToClient(new Point(e.X, e.Y));
            //_form.Controls.Add()
        }



        void puzzle_MouseDown(object sender, MouseEventArgs e)
        {
            SetSmallPuzzlesLocation setSmallPuzzles = new SetSmallPuzzlesLocation();
            Puzzle puzzleImage = (Puzzle)sender;
        
           //puzzleImage.BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                if (puzzleImage == null) return;
                puzzleImage.DoDragDrop(puzzleImage, DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right)
            {
                puzzleImage.Size = new Size(puzzleImage.Size.Height, puzzleImage.Size.Width);
                if (puzzleImage.ImageDegree != 270)
                {
                    puzzleImage.ImageDegree += 90;
                }
                else
                {
                    puzzleImage.ImageDegree = 0;
                }
                puzzleImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                if (puzzleImage.topPuzzle.Image != null)
                {
                    puzzleImage.topPuzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    setSmallPuzzles.SetTopPuzzleLocation(puzzleImage);
                    puzzleImage.topPuzzle.Invalidate(); 
                }
                if (puzzleImage.rightPuzzle.Image != null)
                {
                    puzzleImage.rightPuzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    setSmallPuzzles.SetRightPuzzleLocation(puzzleImage);
                    puzzleImage.rightPuzzle.Invalidate(); 
                }

                if (puzzleImage.bottomPuzzle != null)
                {
                    setSmallPuzzles.SetBottomPuzzleLocation(puzzleImage);                  
                }
                if (puzzleImage.leftPuzzle != null)
                {
                    setSmallPuzzles.SetLeftPuzzleLocation(puzzleImage);
                }
              

               
                puzzleImage.Invalidate();                
            }

        }

     

        void puzzle_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void puzzle_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            CheckForPictureBuildCorrectness pictureCorrectness = new CheckForPictureBuildCorrectness(_form, _basePuzzleList);
            bool correct = pictureCorrectness.Check(_mixedPuzzleList);
            if (correct)
            {
                pictureCorrectness.Winner(_mixedPuzzleList);
            }
        }

    }
}

//Puzzle puzzleSource = (Puzzle)sender;
//var controls = _form.Controls.Cast<Control>();

//List<Puzzle> puzzlesTarget = controls
//    .Where(x => x.Bounds.IntersectsWith(puzzleSource.Bounds)
//        && x != puzzleSource && x.GetType() == typeof(Puzzle)).Cast<Puzzle>()
//    .ToList();
//DropPuzzleNearOther dropPuzzles = new DropPuzzleNearOther(puzzleSource);
//dropPuzzles.PlacePuzzles(puzzlesTarget);
