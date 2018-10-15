using Killer_Sudoku.TetrisFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.KillerSudokuBoard
{
    class Board
    {
        private int size;
        private int[,] values;
        private Cell [,] board;

        public Board(int size)
        {
            this.size = size;
            this.values = ArrayExt.InitIntMatrix(size);
            this.board= new Cell[size, size];
            InitBoard(size);
            ArrayExt.Print2DArray(this.values);
        }

        public void InitBoard (int size)
        {
            for (int i=0; i<size; i++)
            {
                for (int j = 0; i < size; i++)
                {
                    this.board[i, j] = new Cell();
                }
            }
        }
    }
}
