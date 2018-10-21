using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    class Gun : TetrisFigure
    {
        public override void InitFigureCoordinates(int[] pivot)
        {
            MaxRotation = 3;
            Type = "gun";
            int[,] blockCoordinates = { { pivot[0], pivot[1] }, { pivot[0], pivot[1]+1 }, { pivot[0]+1, pivot[1] + 1 }};
            InitCells(blockCoordinates);
        }
    }
}
