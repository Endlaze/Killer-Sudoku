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
        int[,] board = new int[5,5];
        GenericBoard[] boardList;
        int threads;
        List<TetrisFigure> figuresToSolve;

        public KillerSudokuSolver(int length, int threads, Board killerBoard)
        {
            this.figuresToSolve = killerBoard.boardFigures;
            this.threads = threads;
            this.length = length;
            boardList = new GenericBoard[length];
            SetPermutationsForAllFigures();
            solveSudoku(0, board);
        }

        public int[,] GetSudokuBoard()
        {
            return this.board;
        }

        public void startThreads()
        {

        }

        public bool solveSudoku(int figureIndex, int[,] tablero)
        {
            figuresToSolve[figureIndex].UsedPermutations = Utils.Utils.InitListWithIndices(figuresToSolve[figureIndex].Positions.Length);
            if (figureIndex == figuresToSolve.Count)
            {
                return true;
            }
            else if (figuresToSolve[figureIndex].FigurePermutations.Count == 1)
            {
                tablero[figuresToSolve[figureIndex].Positions.ElementAt(0).Position[0],
                    figuresToSolve[figureIndex].Positions.ElementAt(0).Position[1]] = figuresToSolve[figureIndex].Result;

                if (solveSudoku(++figureIndex, tablero)) {
                    return true;
                }
                return false;
                
            }
            else
            {
                for (int i = 0; i < figuresToSolve[figureIndex].FigurePermutations.Count; i++)
                {
                    
                    if (PermutationIsValid(GetPermutation(figureIndex), figuresToSolve[figureIndex].Positions , tablero, figureIndex))
                    {
                        //ArrayExt.Print2DArray(tablero);
                        Console.WriteLine("");
                        if (solveSudoku(++figureIndex, tablero) == true)
                        {
                            return true;
                        }
                    }
                }
                Console.WriteLine("No encontre nada, Back");
                tablero = SetNumbersInBoard(Utils.Utils.InitListWithNumber(0, figuresToSolve[figureIndex].Positions.Length), figuresToSolve[figureIndex], tablero);
                figuresToSolve[figureIndex].UsedPermutations = Utils.Utils.InitListWithIndices(figuresToSolve[figureIndex].Positions.Length);
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
        private List<int> GetPermutation(int figureIndex)
        {
            Random random = new Random();
            
            int index = random.Next(0, figuresToSolve.ElementAt(figureIndex).UsedPermutations.Count);
            Console.WriteLine("{0}    {1}",index, figuresToSolve.ElementAt(figureIndex).UsedPermutations.Count);
            int number = figuresToSolve.ElementAt(figureIndex).UsedPermutations.ElementAt(index);
            figuresToSolve.ElementAt(figureIndex).UsedPermutations.RemoveAt(index);
            ArrayExt.PrintArray(figuresToSolve.ElementAt(figureIndex).FigurePermutations.ElementAt(number).ToArray());
            Console.WriteLine(figuresToSolve.ElementAt(figureIndex).Operation);
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
                figure.SetFigurePermutations(this.length);
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
