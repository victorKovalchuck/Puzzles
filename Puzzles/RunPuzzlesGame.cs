using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Core.FactoryMethod;
using Core.FactoryMethod.Algorithm1;
using Utilits;

namespace Puzzles
{
    public class RunPuzzlesGame
    {
        Form1 _form;
        PictureBox _image;
        List<Puzzle> basicPictureLocationList;
        public RunPuzzlesGame(Form1 form, PictureBox image)
        {
            this._form = form;
            this._image = image;
        }

        public void Start()
        {
            FactoryBase factory = new PuzzleBrakeCoupleAlgorithm();
            Puzzle[,] puzzles = factory.CreatePuzzles();
            List<Puzzle> puzzlesList = factory.ModifyPuzzles(puzzles);

            SetPuzzleImage setImagesToPuzzles = new SetPuzzleImage(_image);
            puzzlesList = setImagesToPuzzles.SetImage(puzzlesList);

            basicPictureLocationList = puzzlesList.Clone<Puzzle>().ToList();           
            ThrowPuzzlesOnDesk throwPuzzles = new ThrowPuzzlesOnDesk(_form, _image);
            List<Puzzle> puzzlesPictureBox = throwPuzzles.Throw(puzzlesList);
            PuzzleEventHandlers eventHandlers = new PuzzleEventHandlers(_form);
            eventHandlers.SetHandlers(puzzlesPictureBox);
        }

        public void BuildPicture()
        {
            if (basicPictureLocationList != null)
            {
                AutoConstructPicture picture = new AutoConstructPicture(_form);
                picture.Construct(basicPictureLocationList);
            }
        }
    }
}
