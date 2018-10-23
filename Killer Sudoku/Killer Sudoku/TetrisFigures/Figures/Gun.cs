using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    
    public class Gun : TetrisFigure
    {
        public Gun() { }
        public override void InitFigureCoordinates(int[] pivot)
        {
            MaxRotation = 3;
            Type = "gun";
            int[,] blockCoordinates = { { pivot[0], pivot[1] }, { pivot[0], pivot[1]+1 }, { pivot[0]+1, pivot[1] + 1 }};
            InitCells(blockCoordinates);
        }
    }
}
