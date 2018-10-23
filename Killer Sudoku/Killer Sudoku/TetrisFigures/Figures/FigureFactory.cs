using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    public class FigureFactory
    {
        
        public static TetrisFigure GetNewFigure(string figure, int size=0)
        {
            switch (figure.ToLower())
            {
                case "block":
                    return new Block();
                    break;
                case "gun":
                    return new Gun();
                    break;
                case "skew":
                    return new Skew();
                    break;
                case "straight":
                    return new Straight(size);
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
