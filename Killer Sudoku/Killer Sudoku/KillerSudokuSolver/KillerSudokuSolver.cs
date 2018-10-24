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
        bool finish = false;
        Random random = new Random();
        static bool isCompleted = false;
        int length;
        int[,] board;
        GenericBoard[] boardList;
        int threads;
        List<TetrisFigure> figuresToSolve;

        public KillerSudokuSolver(int length, int threads, Board killerBoard)
        {
            this.board = new int[length, length];
            this.figuresToSolve = killerBoard.boardFigures;
            this.threads = threads;
            this.length = length;
            SetPermutationsForAllFigures();
        }
        public void start()
        {
            Parallel.For(0, threads, index =>
            {
                solveSudoku(0, new int[length,length], new List<int>());
            });
            
        }

        public int[,] GetSudokuBoard()
        {
            return this.board;
        }


        public bool solveSudoku(int figureIndex, int[,] tablero, List<int> usedPermutations)
        {
            if (finish)
            {
                return true;
            }
            
            if (figureIndex == figuresToSolve.Count)
            {
                finish = true;
                board = tablero;
                return true;
            }
            usedPermutations = Utils.Utils.InitListWithIndices(figuresToSolve[figureIndex].FigurePermutations.Count);
            if (figuresToSolve[figureIndex].Positions.Length == 1 )
            {
                tablero[figuresToSolve[figureIndex].Positions.ElementAt(0).Position[0],
                    figuresToSolve[figureIndex].Positions.ElementAt(0).Position[1]] = figuresToSolve[figureIndex].Result;

                if (solveSudoku(++figureIndex, tablero, usedPermutations)) {
                    return true;
                }
                return false;
                
            }
            else
            {
                
                for (int i = 0; i < figuresToSolve[figureIndex].FigurePermutations.Count; i++)
                {
                    
                    if (PermutationIsValid(GetPermutation(figureIndex, usedPermutations), figuresToSolve[figureIndex].Positions , tablero, figureIndex))
                    {

                        if (solveSudoku(++figureIndex, tablero, usedPermutations) == true)
                        {
                            return true;
                        }
                        else
                        {
                            figureIndex--;
                            tablero = SetNumbersInBoard(Utils.Utils.InitListWithNumber(0, figuresToSolve[figureIndex].Positions.Length), figuresToSolve[figureIndex], tablero);
                        }
                    }
                }
                tablero = SetNumbersInBoard(Utils.Utils.InitListWithNumber(0, figuresToSolve[figureIndex].Positions.Length), figuresToSolve[figureIndex], tablero);
                usedPermutations = Utils.Utils.InitListWithIndices(figuresToSolve[figureIndex].FigurePermutations.Count);
                return false;
            }
        }
        private bool PermutationIsValid (List<int> permutation, Cell[] positions, int[,] tablero, int index)
        {
            
            for (int i = 0; i< positions.Length; i++)
            {
                if (IsInRow(positions[i].Position[0], permutation[i], tablero) || IsInCol(positions[i].Position[1], permutation[i], tablero))
                {
                    return false;
                }
            }
            tablero = SetNumbersInBoard(permutation, figuresToSolve[index], tablero);
            return true;
        }
        private List<int> GetPermutation(int figureIndex, List<int> usedPermutations)
        {
            int index = random.Next(0, usedPermutations.Count);
            int number = usedPermutations.ElementAt(index);
            usedPermutations.RemoveAt(index);
            return figuresToSolve.ElementAt(figureIndex).FigurePermutations.ElementAt(number);
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

        private void SetPermutationsForAllFigures()
        {
            foreach (var figure in figuresToSolve)
            {
                figure.SetFigurePermutations(this.length, figure.Type);
            }
        }

        private int[,] SetNumbersInBoard(List<int> permutation, TetrisFigure figure,  int [,] tablero)
        {
            for (int i = 0; i < figure.Positions.Length; i++)
            {
                tablero[figure.Positions.ElementAt(i).Position[0], figure.Positions.ElementAt(i).Position[1]] = permutation.ElementAt(i);
            }
            return tablero;
        }
    }
    
}
