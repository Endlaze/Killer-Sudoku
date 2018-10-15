using Killer_Sudoku.TetrisFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    abstract class TetrisFigure
    {
        private Cell[] blocks;
        private string color;
        private int result;

        //Blocks setter & getter
        public Cell[] Positions
        {
            get { return this.blocks; }
            set { this.blocks = value; }
        }

        //Color setter & getter
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        //Operation value setter & getter
        public int Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

        //Function to init array
        public void InitCells(int [,] coordinates)
        {
            this.blocks = new Cell[coordinates.GetLength(0)];
            for (int i=0; i< coordinates.GetLength(0); i++)
            {
                blocks[i] = new Cell();
                blocks[i].Position = ArrayExt.GetRow(coordinates, i);
            }
        }

        //Rotate function
        public void Rotate()
        {
            int[,] rotationMatrix = { {0,-1 }, {1,0} };

            for (int i=1; i<this.blocks.GetLength(0); i++)
            {
                this.blocks[i].Position = ArrayOperations.SubtractArray(this.blocks[i].Position,this.blocks[0].Position);
                this.blocks[i].Position = ArrayOperations.MultArrayByMatrix(this.blocks[i].Position,rotationMatrix);
                this.blocks[i].Position = ArrayOperations.SumArray(this.blocks[i].Position, this.blocks[0].Position);
            }
        }

        public abstract void InitFigureCoordinates(int[] pivot);
    }
}
