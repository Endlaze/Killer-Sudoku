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
           // figuresToSolve = figuresToSolve.OrderBy(x => x.FigurePermutations.Count).ToList();   
        }
        public void start(int[,] tablero, List<int> usedPermutations, int test)
        {
            Console.WriteLine(test);
            solveSudoku(0, tablero, usedPermutations, test);
        }

        public int[,] GetSudokuBoard()
        {
            return this.board;
        }


        public bool solveSudoku(int figureIndex, int[,] tablero, List<int> usedPermutations, int test)
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

                if (solveSudoku(++figureIndex, tablero, usedPermutations, test)) {
                    return true;
                }
                return false;
                
            }
            else
            {
                
                //Console.WriteLine("LA FIGURA {0} HARA EL CICLO {1} VECES", figureIndex, figuresToSolve[figureIndex].FigurePermutations.Count);
                for (int i = 0; i < figuresToSolve[figureIndex].FigurePermutations.Count; i++)
                {
                    
                    if (PermutationIsValid(GetPermutation(figureIndex, usedPermutations), figuresToSolve[figureIndex].Positions , tablero, figureIndex))
                    {
                       // ArrayExt.Print2DArray(tablero);
                        //Console.WriteLine("");
                        if (solveSudoku(++figureIndex, tablero, usedPermutations, test) == true)
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
               // Console.WriteLine("No encontre nada, este es el tablero antes de borrar");
                //ArrayExt.Print2DArray(tablero);
                //Console.WriteLine("");
                tablero = SetNumbersInBoard(Utils.Utils.InitListWithNumber(0, figuresToSolve[figureIndex].Positions.Length), figuresToSolve[figureIndex], tablero);
                usedPermutations = Utils.Utils.InitListWithIndices(figuresToSolve[figureIndex].FigurePermutations.Count);
                //Console.WriteLine("TABLERO BORRADO");
                //ArrayExt.Print2DArray(tablero);
                //Console.WriteLine("");
                return false;
            }
        }
        private bool PermutationIsValid (List<int> permutation, Cell[] positions, int[,] tablero, int index)
        {
            
            for (int i = 0; i< positions.Length; i++)
            {
               // ArrayExt.Print2DArray(tablero);
               // Console.WriteLine("");
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

            //Console.WriteLine("FIGURA #{0}", figureIndex);
            int index = random.Next(0, usedPermutations.Count);
            //Console.WriteLine("{0}    {1}",index, figuresToSolve.ElementAt(figureIndex).UsedPermutations.Count);
            int number = usedPermutations.ElementAt(index);
            usedPermutations.RemoveAt(index);
            //Console.WriteLine("Permutacion que intenta usar");
            //ArrayExt.PrintArray(figuresToSolve.ElementAt(figureIndex).FigurePermutations.ElementAt(number).ToArray());
            //Console.WriteLine("En las posiciones");
          /*  foreach (var item in figuresToSolve.ElementAt(figureIndex).Positions)
            {
                ArrayExt.PrintArray(item.Position);
            }*/
            
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
