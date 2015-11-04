using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Utilits
{
    public class Puzzle : PictureBox, ICloneable,IComparable<Puzzle>
    {
        int _coordinateX;
        int _coordinateY;
        int _imageOrder;
        int _width = 70;
        int _height = 50;        
        int _imageDegree;
        public bool Changed = false;
        public Puzzle[] divededPuzzles = new Puzzle[2];

        public List<Puzzle> leftPuzzle;
        public Puzzle rightPuzzle;
        public Puzzle topPuzzle;
        public List<Puzzle> bottomPuzzle;


        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public int CoordinateX
        {
            get
            {
                return _coordinateX;
            }
            set
            {
                _coordinateX = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return _coordinateY;
            }
            set
            {
                _coordinateY = value;
            }
        }

        public int ImageDegree
        {
            get
            {
                return _imageDegree;
            }
            set
            {
                _imageDegree = value;
            }
        }

        public int ImageOrder
        {
            get
            {
                return _imageOrder;
            }
            set
            {
                _imageOrder = value;
            }
        }
        public object Clone()
        {
            Puzzle newPuzzle = (Puzzle)this.MemberwiseClone();
           
                newPuzzle.Image = (Image)this.Image.Clone();
            
            return newPuzzle;
        }

        public int CompareTo(Puzzle other)
        {
            if (other == null)
            {
                return 1;
            }
            return this._imageOrder.CompareTo(other._imageOrder);
        }

    }
}
