using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Killer_Sudoku
{
    class Tetris
    {
        const int lenght = 20;
        static int[,] board = new int[lenght,lenght];
        public void Main()
        {

            solveSudoku(0, 0, 1);
            for(int i = 0; i< lenght; i++)
            {
                for (int j = 0; j< lenght; j++)
                {
                    Console.Write(" ");
                    Console.Write(board[i,j]);
                }
                Console.WriteLine("");
            }
        }

        public static bool solveSudoku(int row, int col, int testNumber)
        {
            if (row == lenght)
            {
                return true;
            }
            else if(board[row,col] != 0)
            {
                return next(1, row, col);
            }
            else
            {
                testNumber = 1;
                for (; testNumber <= lenght; testNumber++)
                {
                    if(IsInRow(row, testNumber) || IsInCol(col, testNumber))
                    {
                        continue;
                    }
                    else
                    {
                        board[row, col] = testNumber;
                        if (next(testNumber,row,col))
                        {
                            return true;
                        } 
                    }
                }
                board[row, col] = 0;
                return false;
            }
            
        }

        public static bool next(int testNum, int row, int col)
        {
            if (col == lenght - 1)
            {
                return solveSudoku(++row, 0, testNum);
            }
            else
            {
                return solveSudoku(row, ++col, testNum);
            }
        }

        public static bool IsInRow(int row, int number)
        {
            for (int col = 0; col < lenght; col++)
            {
                if (board[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsInCol(int col, int number)
        {
            for (int row = 0; row < lenght; row++)
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



