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
        public PuzzleEventHandlers(Form1 form)
        {
            _form = form;
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
                
                ((Control)puzzle).AllowDrop = true;
            }
            
        }

        void puzzle_DragOver(object sender, DragEventArgs e)
        {
          
        }

        
        void puzzle_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Puzzle puzzleImage = (Puzzle)sender;
            Point relativePoint = _form.PointToClient(Cursor.Position);
            puzzleImage.Location = new Point(relativePoint.X - puzzleImage.Size.Width / 2, relativePoint.Y - puzzleImage.Size.Height / 2);


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
            Puzzle puzzleImage = (Puzzle)sender;
            puzzleImage.BringToFront();
            if (e.Button == MouseButtons.Left)
            {                
                if (puzzleImage == null) return;
                puzzleImage.DoDragDrop(puzzleImage, DragDropEffects.Move);
            }
            else if (e.Button == MouseButtons.Right)
            {
                puzzleImage.Size = new Size(puzzleImage.Size.Height, puzzleImage.Size.Width);
                puzzleImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                puzzleImage.Invalidate();
                
            }
           
        }

        void puzzle_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;            
        }

        void puzzle_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Puzzle puzzleSource = (Puzzle)sender;
            var controls = _form.Controls.Cast<Control>();

            Puzzle puzzleTarget = controls
                .Where(x => x.Bounds.IntersectsWith(puzzleSource.Bounds) 
                    && x != puzzleSource && x.GetType()==typeof(Puzzle))
                .SingleOrDefault() as Puzzle;

        }

    }
}
