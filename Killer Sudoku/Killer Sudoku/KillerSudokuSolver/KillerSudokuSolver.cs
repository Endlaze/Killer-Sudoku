using Killer_Sudoku.KillerSudokuBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.KillerSudokuSolver
{
    class KillerSudokuSolver
    {
        
        static bool isCompleted = false;
        int length;
        int[,] board;
        GenericBoard[] boardList;
        int threads;
        List <TetrisFigure> figuresToSolve;
        public KillerSudokuSolver(int length, int threads, Board killerBoard)
        {
            this.figuresToSolve = killerBoard.boardFigures;
            this.threads = threads;
            this.length = length;
            boardList = new GenericBoard[length];
            startThreads();
        }

        public int[,] GetSudokuBoard()
        {
            return board;
        }

        public void startThreads()
        {
            for (int i = 0; i < length; i++)
            {
                boardList[i] = new GenericBoard(length);
            }
            Parallel.For(0, threads, numero =>
            {
                boardList[numero].isSolving = true;
                solveSudoku(0, 0, boardList[numero].boardy, numero + 1);
            });
        }

        public bool solveSudoku(int row, int col, int[,] tablero, int testNumber = 1)
        {

            if (isCompleted)
            {
                return false;
            }

            else if (tablero[row, col] != 0)
            {
                return nextCell(row, col, tablero);
            }
            else
            {
                foreach (var piece in figuresToSolve)
                {
                    for (; testNumber <= length; testNumber++)
                    {
                        if (IsInRow(row, testNumber, tablero) || IsInCol(col, testNumber, tablero) || isCompleted)
                        {
                            continue;
                        }
                        else
                        {
                            tablero[row, col] = testNumber;
                            if (nextCell(row, col, tablero))
                            {
                                return true;
                            }
                        }
                    }
                    tablero[row, col] = 0;
                    return false;
                }
                return false;
                
            }

        }


        private bool nextBoard()
        {
            for (int i = 0; i < boardList.Length; i++)
            {
                if (boardList[i].isSolving == false)
                {
                    boardList[i].isSolving = true;
                    return solveSudoku(0, 0, boardList[i].boardy, i + 1);
                }
            }
            return false;
        }

        private bool nextCell(int row, int col, int[,] tablero)

        {
            if (col == length - 1)
            {
                return solveSudoku(++row, 0, tablero);
            }
            else
            {
                return solveSudoku(row, ++col, tablero);
            }
        }


        private bool IsInRow(int row, int number, int[,] tablero)

        {
            for (int col = 0; col < length; col++)
            {
                if (tablero[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsInCol(int col, int number, int[,] tablero)

        {
            for (int row = 0; row < length; row++)
            {
                if (tablero[row, col].Equals(number))
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
