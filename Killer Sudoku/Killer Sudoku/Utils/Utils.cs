using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.Utils
{
    public static class Utils
    {
        public static int GiveMeANumber(int [] excludedNumbers,int minRange ,int maxRange)
        {
            var exclude = new HashSet<int>(excludedNumbers);

            var range = Enumerable.Range(0, maxRange).Where(i => !exclude.Contains(i));
            var rand = new System.Random();
            int index = rand.Next(minRange, maxRange - exclude.Count);
            return range.ElementAt(index);
        }
    }
}
