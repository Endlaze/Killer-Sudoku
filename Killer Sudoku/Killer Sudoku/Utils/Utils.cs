using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static Color GetNewColor (Color color)
        {
            
            Color newColor = color;

            while (newColor.Equals(color))
            {
                Random rand = new Random();
                Random rand1 = new Random();
                Random rand2 = new Random();
                int r = rand1.Next(100, 255);
                int g = rand2.Next(100, 255);
                int b = rand2.Next(100, 255);
                newColor =Color.FromArgb(r, g, b);
            }
            

            return newColor;
        }

        public static List<int> InitListWithIndices(int maxRange)
        {
            return Enumerable.Range(0, maxRange).ToList();
        }
    } 
}
