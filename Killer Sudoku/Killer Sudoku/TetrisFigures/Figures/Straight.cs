using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    class Straight: TetrisFigure
    {
        int size;
        public Straight(int size) {
            this.size = size;
            Type = "straight";
        }

        public override void InitFigureCoordinates(int[] pivot)
        {
            MaxRotation = 1;
            int[,] blockCoordinates = new int [this.size,2];

            for (int i=0; i<size; i++)
            {
                blockCoordinates[i, 0] = pivot[0];
                blockCoordinates[i, 1] = pivot[1] + i;
            }
            InitCells(blockCoordinates);
        }
    }
}
