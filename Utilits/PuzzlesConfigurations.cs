using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Utilits
{
    public class PuzzlesConfigurations
    {
        static int _horizontalPuzzlesNumbers = 4;
        static int _verticalPuzzlesNumbers = 5;
        public enum puzzleBrakeCoupleEnum { horizontalDivide, verticalCouple, untouchable, verticalDivide, horizontalCouple };
        public enum rotateVariants { Rotate0 = 0, Rotate90 = 90, Rotate180 = 180, Rotate270 = 270 };
        public enum StrategyTypeEnum { Identical = 0, Different = 1 };
        public enum ApproximatelyPuzzlesNumbers { Size4x5, Size3x4 };

        public static void SetPuzzlesAmount(Utilits.PuzzlesConfigurations.ApproximatelyPuzzlesNumbers puzzlesNumber)
        {
            switch (puzzlesNumber)
            {
                case PuzzlesConfigurations.ApproximatelyPuzzlesNumbers.Size4x5:
                    Horizontal = 4;
                    Vertical = 5;
                    break;
                case PuzzlesConfigurations.ApproximatelyPuzzlesNumbers.Size3x4:
                    Horizontal = 3;
                    Vertical = 4;
                    break;
            }
        }

        public static int Horizontal
        {
            get
            {
                return _horizontalPuzzlesNumbers;
            }
            private set
            {
                _horizontalPuzzlesNumbers = value;
            }
        }

        public static int Vertical
        {
            get
            {
                return _verticalPuzzlesNumbers;
            }
            private set
            {
                _verticalPuzzlesNumbers = value;
            }

        }
    }
}
