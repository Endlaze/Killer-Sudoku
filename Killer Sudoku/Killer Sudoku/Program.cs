using Killer_Sudoku.TetrisFigures.Figures;
using System;
using Killer_Sudoku.KillerSudokuSolver;
using Killer_Sudoku.KillerSudokuBoard;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

using Killer_Sudoku.TetrisFigures;
using System.Linq;
using System.Threading.Tasks;

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
            Board board = new Board(17, 10);
             ArrayExt.Print2DArray(board.values);
             Console.WriteLine("Terminó de generar el board");
             KillerSudokuSolver.KillerSudokuSolver solving = new KillerSudokuSolver.KillerSudokuSolver(17, 1, board);
            Parallel.For(0, 15, numero =>
            {
                solving.start(new int[17, 17], new List<int>(), numero);
            });
            
            ArrayExt.Print2DArray(solving.GetSudokuBoard());





        }   
    }
}
