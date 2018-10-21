using Killer_Sudoku.KillerSudokuBoard;
using Killer_Sudoku.TetrisFigures;
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
        List<TetrisFigure> figuresToSolve;

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

        public bool solveSudoku(int figureIndex, int[,] tablero)

        {
            if (figureIndex == figuresToSolve.Count)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < figuresToSolve[figureIndex].FigurePermutations.Count; i++)
                {

                    if (PermutationIsValid(GetPermutation(figureIndex), figuresToSolve[figureIndex].Positions , tablero))
                    {

                        if (solveSudoku(++figureIndex, tablero) == true)
                        {
                            return true;
                        }
                    }
                }
                figuresToSolve[figureIndex].UsedPermutations = Utils.Utils.InitListWithIndices(figuresToSolve[figureIndex].Positions.Length);
                return false;
            }
        }
        private bool PermutationIsValid (List<int> permutation, Cell[] positions, int[,] tablero)
        {
            for (int i = 0; i< positions.Length; i++)
            {
                if (IsInRow(positions[i].Position[0], permutation[i], tablero) || IsInCol(positions[i].Position[1], permutation[i], tablero))
                {
                    return false;
                }
            }
            return true;
        }
        private List<int> GetPermutation(int figureIndex)
        {
            Random random = new Random();
            int index = random.Next(0, figuresToSolve[figureIndex].UsedPermutations.Count);
            int number = figuresToSolve[figureIndex].UsedPermutations[index];
            figuresToSolve[figureIndex].UsedPermutations.RemoveAt(index);
            return figuresToSolve[figureIndex].FigurePermutations[number];
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
