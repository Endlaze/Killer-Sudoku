using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Killer_Sudoku.TetrisFigures.Figures
{
    
    public class Block : TetrisFigure
    {
        public Block() { }
        public override void InitFigureCoordinates(int[] pivot)
        {
            MaxRotation = 0;
            Type = "block";
            int[,] blockCoordinates = { { pivot[0], pivot[1] }, { pivot[0], pivot[1]+1 }, { pivot[0]+1, pivot[1]+1 }, { pivot[0]+1, pivot[1]}};
            InitCells(blockCoordinates);
        }
    }
}
