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

        public static List<List<int>> GetFigureMulPermutations(int number, int figureSize, int boardLength)
        {
            List<List<int>> multiplyPermutations = new List<List<int>>();
            IEnumerable<IEnumerable<int>> permutations = GetMulPermutations(GetDivisors(number, boardLength), figureSize);
            foreach (var item in permutations)
            {
                if (item.Aggregate((x, y) => x * y) == number)
                {
                    multiplyPermutations.Add(item.ToList());
                }
            }
            return multiplyPermutations;
        }

        public static List<int> GetDivisors(int number, int boardLenght)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= boardLenght; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }

        static IEnumerable<IEnumerable<T>>
            GetMulPermutations<T>(IEnumerable<T> list, int largo)
        {
            if (largo == 1) return list.Select(t => new T[] { t });
            return GetMulPermutations(list, largo - 1)
            .SelectMany(t => list.Where(o => !t.Contains(o)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}

