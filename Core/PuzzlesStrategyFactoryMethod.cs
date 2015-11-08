using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilits;
using Core.Algorithm1;

namespace Core
{
  public  class PuzzlesStrategyFactoryMethod
  {
      Image _image;
      public PuzzlesStrategyFactoryMethod(Image image)
      {
          _image = image;
      }

        public IPuzzlesStrategy GetStrategy(PuzzlesConfigurations.StrategyTypeEnum strategyType)
        {
            switch (strategyType)
            {
                case PuzzlesConfigurations.StrategyTypeEnum.Different:
                    return new DifferentSizePuzzlesStrategy(_image);
                default:
                    return new IdenticalSizePuzzlesStrategy(_image);
            }
        }
    }
}
