using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    class Block : TetrisFigure
    {
        public override void InitFigureCoordinates(int[] pivot)
        {
            int[,] blockCoordinates = { { pivot[0], pivot[1] }, { pivot[0]+1, pivot[1] }, { pivot[0], pivot[1]+1 }, { pivot[0]+1, pivot[1]+1}};
            InitCells(blockCoordinates);
        }
    }
}
