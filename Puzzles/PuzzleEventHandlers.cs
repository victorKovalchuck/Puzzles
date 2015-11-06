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
        FormGameTable _form;
        List<Puzzle> _basePuzzleList;
        List<Puzzle> _mixedPuzzleList;
        SetSmallPuzzlesLocation smallPuzzles = new SetSmallPuzzlesLocation();
        Label title;
        Panel panel;
        int differnceBetweenCursorAndPuzzleX;
        int differnceBetweenCursorAndPuzzleY;
        int startCoorddinateX;
        int startCoorddinateY;       
       
        public PuzzleEventHandlers(FormGameTable form, List<Puzzle> basePuzzleList, List<Puzzle> mixedPuzzleList)
        {
            _form = form;
            _basePuzzleList = basePuzzleList;
            _mixedPuzzleList = mixedPuzzleList;
           
        }

        public void SetHandlers(PictureBox image)
        {

            foreach (Puzzle puzzle in _mixedPuzzleList)
            {                         
                puzzle.DragDrop += new System.Windows.Forms.DragEventHandler(puzzle_DragDrop);
                puzzle.DragEnter += new System.Windows.Forms.DragEventHandler(puzzle_DragEnter);
                puzzle.MouseDown += new MouseEventHandler(puzzle_MouseDown);
                puzzle.GiveFeedback += new GiveFeedbackEventHandler(puzzle_GiveFeedback);          
             
                ((Control)puzzle).AllowDrop = true;
            }

            SetPanel(image);
        }
          
        void puzzle_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

            Puzzle puzzle = (Puzzle)sender;
            Point relativePoint = _form.PointToClient(Cursor.Position);
            puzzle.Location = new Point(Cursor.Position.X - differnceBetweenCursorAndPuzzleX, Cursor.Position.Y - differnceBetweenCursorAndPuzzleY);
            puzzle.topPuzzle.AllowDrop = true;
            smallPuzzles.SetTopPuzzleLocation(puzzle);
            smallPuzzles.SetBottomPuzzleLocation(puzzle);
            smallPuzzles.SetRightPuzzleLocation(puzzle);
            smallPuzzles.SetLeftPuzzleLocation(puzzle);           
            puzzle.Refresh();     
        }      


        void puzzle_MouseDown(object sender, MouseEventArgs e)
        {

            Puzzle puzzle = (Puzzle)sender;
            differnceBetweenCursorAndPuzzleX = Cursor.Position.X - puzzle.Location.X;
            differnceBetweenCursorAndPuzzleY = Cursor.Position.Y - puzzle.Location.Y;
            startCoorddinateX = puzzle.Location.X;
            startCoorddinateY = puzzle.Location.Y;
            puzzle.topPuzzle.BringToFront();
            puzzle.rightPuzzle.BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                if (puzzle == null) return;
                puzzle.DoDragDrop(puzzle, DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right)
            {
                puzzle.Size = new Size(puzzle.Size.Height, puzzle.Size.Width);
                if (puzzle.ImageDegree != 270)
                {
                    puzzle.ImageDegree += 90;
                }
                else
                {
                    puzzle.ImageDegree = 0;
                }
                puzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                if (puzzle.topPuzzle.Image != null)
                {
                    puzzle.topPuzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    smallPuzzles.SetTopPuzzleLocation(puzzle);
                    puzzle.topPuzzle.Invalidate();
                }
                if (puzzle.rightPuzzle.Image != null)
                {
                    puzzle.rightPuzzle.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    smallPuzzles.SetRightPuzzleLocation(puzzle);
                    puzzle.rightPuzzle.Invalidate();
                }

                if (puzzle.bottomPuzzle != null)
                {
                    smallPuzzles.SetBottomPuzzleLocation(puzzle);
                }
                if (puzzle.leftPuzzle != null)
                {
                    smallPuzzles.SetLeftPuzzleLocation(puzzle);
                }
                puzzle.Invalidate();
            }
        }

     

        void puzzle_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void puzzle_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Puzzle puzzle = (Puzzle)sender;
             var controls = _form.Controls.Cast<Control>();
            Panel intersectedPanel = controls
                .Where(x => x.Bounds.IntersectsWith(puzzle.Bounds)
                    && x != puzzle && x.GetType() == typeof(Panel)).Cast<Panel>().FirstOrDefault();
            if (intersectedPanel != null)
            {
                if (title != null)
                {
                    title.Visible = false;
       
                }
            }
            else
            {
                puzzle.Location = new Point(startCoorddinateX, startCoorddinateY);
                smallPuzzles.SetTopPuzzleLocation(puzzle);
                smallPuzzles.SetBottomPuzzleLocation(puzzle);
                smallPuzzles.SetLeftPuzzleLocation(puzzle);
                smallPuzzles.SetRightPuzzleLocation(puzzle);
            }

            CheckForPictureBuildCorrectness pictureCorrectness = new CheckForPictureBuildCorrectness(_form, _basePuzzleList);
            bool correct = pictureCorrectness.Check(_mixedPuzzleList);
            if (correct)
            {
                pictureCorrectness.Winner(_mixedPuzzleList);
            }
        }



        private void SetPanel(PictureBox image)
        {
            panel = new Panel();
            panel.Location = new Point(_form.Size.Width / 4, 20);
            panel.Size = new Size(_form.Size.Width - _form.Size.Width / 4 - image.Width - 60, image.Image.Size.Height + image.Location.Y - 20);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.Transparent;
            title = new Label();
            title.Width = panel.Width;
            title.Height = panel.Height;
            title.Text = "Game table.Construct image here\nUse image dragdrop feature.Right botton click to rotate image";
            title.AutoSize = false;
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Dock = DockStyle.Fill;
            title.Font = new Font(FontFamily.GenericSansSerif, 12);
            title.ForeColor = Color.Red;
            panel.Controls.Add(title);
            _form.Controls.Add(panel);
        }

        public void DisposePanel()
        {
            title.Dispose();
            panel.Dispose();
        }
    

    }
}

