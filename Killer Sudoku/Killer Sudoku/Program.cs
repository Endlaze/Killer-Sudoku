using Killer_Sudoku.TetrisFigures.Figures;
using System;
using Killer_Sudoku.KillerSudokuSolver;
using Killer_Sudoku.KillerSudokuBoard;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

using Killer_Sudoku.TetrisFigures;
using System.Linq;

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
            /* Board board = new Board(19, 19);
             ArrayExt.Print2DArray(board.values);
             Console.WriteLine("Terminó de generar el board");
             KillerSudokuSolver.KillerSudokuSolver solving = new KillerSudokuSolver.KillerSudokuSolver(19, 1, board);
            Thread t = new Thread(new ThreadStart(solving.start));
           t.Start();
            while (true)
            {
                ArrayExt.Print2DArray(solving.GetSudokuBoard());
                Thread.Sleep(500);
                Console.WriteLine("\n");

            }*/




        }   
    }
}
