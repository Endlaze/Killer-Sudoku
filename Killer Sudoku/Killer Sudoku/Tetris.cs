using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    class Tetris
    {
        int[,] board = new int[5, 5];
        public void Main()
        {
           
            
            generateSudoku(board, 0, 0, 1);
            for(int i = 0; i<5; i++)
            {
                for (int j = 0; j<5; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine("");
            }
        }

        public bool generateSudoku(int[,] tablero, int row, int col, int testNumber)
        {
            if(testNumber == 6)
            {
                return false;
            }
            
            else if (row == 4 && col == 4)
            {
                return true;
            }
            else
            {
                if (!(IsInRow(tablero, row, testNumber) || IsInCol(tablero, col, testNumber)))
                {
                    if (col == 4)
                    {
                        tablero[row, col] = testNumber;

                        if (generateSudoku(tablero, ++row, 0, testNumber) == false)
                        {
                            return generateSudoku(tablero, row, col, ++testNumber);
                        }
                        else
                        {
                            return generateSudoku(tablero, ++row, 0, 1);
                        }
                    }
                    else
                    {
                        tablero[row, col] = testNumber;

                        if(generateSudoku(tablero, row, ++col , testNumber) == false)
                        {
                            return generateSudoku(tablero, row, col, ++testNumber);
                        }
                        else
                        {
                            return generateSudoku(tablero, row, ++col , 1);
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            
        }



        public bool IsInRow(int[,] mat, int row, int number)
        {
            //return row.Contains(number);
            for (int col = 0; col < mat.GetLength(0); col++)
            {
                if (mat[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsInCol(int[,] matrix, int col, int number)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }
    }
}



