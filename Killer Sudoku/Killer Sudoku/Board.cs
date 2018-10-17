using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Board
    {
        public int[,] boardy;
        public bool isSolving = false;
        public Board(int size)
        {
            boardy = new int[size, size];
        }
    }
}
