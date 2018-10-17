using Killer_Sudoku.TetrisFigures.Figures;
using System;
using Killer_Sudoku.KillerSudokuSolver;
using Killer_Sudoku.KillerSudokuBoard;
using System.Windows.Forms;

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
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new GUI());

          

            //SudokuSolver solver = new SudokuSolver();
            // solver.Main();
           

            Board board = new Board(5, "mult");
            board.fitTetrisFigures();
          

            
           
        }
    }
}
