using Killer_Sudoku.TetrisFigures.Figures;
using System;
using Killer_Sudoku.KillerSudokuSolver;
using Killer_Sudoku.KillerSudokuBoard;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
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
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());*/
            List<List<int>> list = new List<List<int>>();
            IEnumerable < IEnumerable < int >> test = GetPermutations(GetDivisors(20),3);
            foreach (var item in test)
            {
                if (item.Aggregate((x, y) => x * y) == 20)
                {
                    list.Add(item.ToList());

                }
                    
            }
            foreach (var nigga in list)
            {
                foreach (var shit in nigga)
                {
                    Console.Write(shit);
                }
                Console.WriteLine(" ");
            }

        }
        public static List<int> GetDivisors(int number)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= 7; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }
        static IEnumerable<IEnumerable<T>>
                    GetPermutations<T>(IEnumerable<T> list, int largo)
        {
            if (largo == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, largo - 1)
            .SelectMany(t => list.Where(o => !t.Contains(o)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
