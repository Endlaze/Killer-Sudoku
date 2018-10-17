using Killer_Sudoku.TetrisFigures.Figures;
using System;
using Killer_Sudoku.KillerSudokuSolver;
using Killer_Sudoku.KillerSudokuBoard;
using System.Windows.Forms;
using System.Threading;

namespace Killer_Sudoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());*/



            Board board = new Board(5, "sum", 1);
            board.fitTetrisFigures();

            foreach (var item in board.boardFigures)
            {
                foreach (var caca in item.Positions)
                {
                    ArrayExt.PrintArray(caca.Position);
                }
                Console.WriteLine("Operacion " + item.Result);
            }
            

        }
    }
}
