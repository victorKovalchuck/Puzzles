using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Core.Algorithm1;
using Utilits;

namespace Puzzles
{
    public class RunPuzzlesGame
    {
        Form1 _form;
        PictureBox _image;
        List<Puzzle> basicPictureLocationList;
        List<Puzzle> mixedPictureLocationList;
        public RunPuzzlesGame(Form1 form, PictureBox image)
        {
            this._form = form;
            this._image = image;
        }

        public void Start()
        {
            FactoryBase factory = new PuzzleBrakeCoupleAlgorithm();
            Puzzle[,] puzzles = factory.CreateIdenticalSizePuzzles();
            List<Puzzle> puzzlesList = factory.CreateDifferentSizePuzzles(puzzles);
            SetPuzzleImage setImagesToPuzzles = new SetPuzzleImage(_image);
            puzzlesList = setImagesToPuzzles.SetImage(puzzlesList);
            SetConjunctionBetweenPuzzles setConnection = new SetConjunctionBetweenPuzzles(puzzlesList, _form,_image);
            setConnection.SetConnection();
           

            basicPictureLocationList = puzzlesList.Clone<Puzzle>().ToList();           
            ThrowPuzzlesOnDesk throwPuzzles = new ThrowPuzzlesOnDesk(_form, _image);
            mixedPictureLocationList = throwPuzzles.Throw(puzzlesList);
            PuzzleEventHandlers eventHandlers = new PuzzleEventHandlers(_form, basicPictureLocationList, mixedPictureLocationList);
            eventHandlers.SetHandlers(mixedPictureLocationList);
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
