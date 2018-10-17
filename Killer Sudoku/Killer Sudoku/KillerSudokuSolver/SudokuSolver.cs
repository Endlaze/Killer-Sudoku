using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.KillerSudokuSolver
{
    class SudokuSolver
    {
        int length;
        int[,] board; 
        
        public int[,] GetSudokuBoard(int length)
        {
            this.length = length;
            this.board = new int[length, length];
            InitSudoku();

            return this.board;
        }
        
        
        public void InitSudoku()
        {
            solveSudoku(0, 0, 1);
        }

        public  bool solveSudoku(int row, int col, int testNumber)
        {
            if (row == length)
            {
                return true;
            }
            else if (board[row, col] != 0)
            {
                return next(1, row, col);
            }
            else
            {
                testNumber = 1;
                for (; testNumber <= length; testNumber++)
                {
                    if (IsInRow(row, testNumber) || IsInCol(col, testNumber))
                    {
                        continue;
                    }
                    else
                    {
                        board[row, col] = testNumber;
                        if (next(testNumber, row, col))
                        {
                            return true;
                        }
                    }
                }
                board[row, col] = 0;
                return false;
            }

        }

        public bool next(int testNum, int row, int col)
        {
            if (col == length - 1)
            {
                return solveSudoku(++row, 0, testNum);
            }
            else
            {
                return solveSudoku(row, ++col, testNum);
            }
        }

        public bool IsInRow(int row, int number)
        {
            for (int col = 0; col < length; col++)
            {
                if (board[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsInCol(int col, int number)
        {
            for (int row = 0; row < length; row++)
            {
                if (board[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
