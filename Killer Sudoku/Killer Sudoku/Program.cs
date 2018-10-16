using Killer_Sudoku.KillerSudokuBoard;
using Killer_Sudoku.TetrisFigures;
using Killer_Sudoku.TetrisFigures.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Killer_Sudoku.KillerSudokuSolver;
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
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());

            int[,] test2 = { { 2, 2 }, { 2, 1 }, { 1, 2 } };

            TetrisFigure figure = FigureFactory.GetNewFigure("skew");
            int [] list = { 5, 1 };
            figure.InitFigureCoordinates(list);

            foreach (var i in figure.Positions)
            {
                ArrayExt.PrintArray(i.Position);
            }
            SudokuSolver solver = new SudokuSolver();
            solver.Main();
        }
    }
}
