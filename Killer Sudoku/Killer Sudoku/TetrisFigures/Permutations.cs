using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures
{
    public class Permutations
    {
        //Function to validate sum permutations
        public static List<List<int>> GetFigureSumPermutations(int number, int figureSize)
        {
            List<List<int>> list = GetSumPermutations(number);
            return FilterPermutations(list, figureSize);
        }

        //Function to get sum permutations

        public static List<List<int>> GetSumPermutations(int number)
        {
            List<List<int>> list = new List<List<int>>() { new List<int>() {number}};
            
            for (int i = 1; i < number; i++)
            {
                foreach (var sublist in GetSumPermutations(number-i))
                {
                    sublist.Insert(0,i);
                    list.Add(sublist);
                }
            }
            return list;
        }

        //Function to filter permutations, given a size
        public static List<List<int>> FilterPermutations(List<List<int>> listToFilter, int figureSize)
        {
            listToFilter = listToFilter.Where(x => x.Count.Equals(figureSize)).ToList();
            List<List<int>> newList = new List<List<int>>();

            for (int x = 0; x < listToFilter.Count; x++)
            {
                bool isEqual = false;
                
                for (int y = 0; y < listToFilter.ElementAt(x).Count-1; y++)
                {
                    if (listToFilter.ElementAt(x).ElementAt(y).Equals(listToFilter.ElementAt(x).ElementAt(y+1)))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    newList.Add(listToFilter.ElementAt(x));
                }
            }
            return newList;
        }
    }
}

