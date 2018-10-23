using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    public class Skew: TetrisFigure
    {
        public Skew()
        {

        }
        public override void InitFigureCoordinates(int[] pivot)
        {
            MaxRotation = 1;
            Type = "skew";
            int[,] blockCoordinates = { { pivot[0], pivot[1] }, { pivot[0], pivot[1]+1 }, { pivot[0]+1, pivot[1] + 1 }, { pivot[0]+1, pivot[1] + 2 } };
            InitCells(blockCoordinates);
        }
    }
}
