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

        private void setPermutationsForAllFigures()
        {
            foreach (var figure in figuresToSolve)
            {
                figure.SetFigurePermutations(this.length);
            }
        }
        
        
    }
    
}
