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
        public static List<List<int>> GetFigureSumPermutations(int number, int figureSize, int boardLenght)
        {
            List<List<int>> list = GetSumPermutations(number);
            return FilterPermutations(list, figureSize, boardLenght);
        }

        //Function to get sum permutations

        public static List<List<int>> GetSumPermutations(int number)
        {
            List<List<int>> list = new List<List<int>>() { new List<int>() {number}};
            
            for (int i = 1; i < number; i++)
            {
               
                foreach (var sublist in GetSumPermutations(number - i))
                {
                    sublist.Insert(0, i);
                    list.Add(sublist);
                }
                
            }
            return list;
        }

        //Function to filter permutations, given a size
        public static List<List<int>> FilterPermutations(List<List<int>> listToFilter, int figureSize, int boardLenght)
        {
            listToFilter = listToFilter.Where(x => x.Count.Equals(figureSize)).ToList();
            listToFilter = listToFilter.Where(x =>  isLess(x, boardLenght)).ToList();

            List<List<int>> newList = new List<List<int>>();

            for (int x = 0; x < listToFilter.Count; x++)
            {
                bool isEqual = false;
                
                for (int y = 0; y < listToFilter.ElementAt(x).Count-1; y++)
                {
                    if (listToFilter.ElementAt(x).ElementAt(y).Equals(listToFilter.ElementAt(x).ElementAt(y+1)) || listToFilter.ElementAt(x).ElementAt(y) > (boardLenght))
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
        public static bool isLess(List<int> listilla, int boardLength)
        {
            foreach (var item in listilla)
            {
                if(item> boardLength)
                {
                    return false;
                }
            }
            return true;
        }

        

        public static List<List<int>> GetFigurePermutations(int number, int figureSize, int boardLength, string operation, string type)
        {
            List<List<int>> multiplyPermutations = new List<List<int>>();
            if (operation == "mult")
                permutation(GetDivisors(number, boardLength), number, Utils.Utils.InitListWithNumber(0, figureSize), 0);
            if(operation == "sum")
                permutation(Utils.Utils.InitListWithIndices(boardLength,1), number, Utils.Utils.InitListWithNumber(0, figureSize), 0);
            bool permutation(List<int> divisors, int numberToReach, List<int> partialPermutation,int limit)
            {
                if (limit == figureSize)
                {
                    if (partialPermutation.Aggregate((x,y) =>  getOperation(x, y, operation)) == numberToReach)
                    {
                        if (!StraightContainsDuplicates(new List<int>(partialPermutation.ToArray()), type))
                        {
                            multiplyPermutations.Add(new List<int>(partialPermutation.ToArray()));
                            return true;
                        }
                    }
                    return true;
                }
                for (int i = 0; i < divisors.Count; i++)
                {
                    partialPermutation[limit] = divisors[i];
                    permutation(divisors, numberToReach, partialPermutation, ++limit);
                    --limit;
                }
                return true;
            }

            return multiplyPermutations.Where((x) => different(x)).ToList();
        }
        private static int getOperation(int a, int b, string operation)
        {
            switch (operation)
            {
                case "sum":
                    return a + b;
                case "mult":
                    return a * b;
                default:
                    return 0;
            }
        }

        private static bool StraightContainsDuplicates(List<int> list, string figureType)
        {
            if ((list.Count != list.Distinct().Count()) && (figureType.Equals("straight")))
            {
                return true;
            }
            
            return false;
        }


        private static bool different(List<int> lista)
        {
            for (int i = 0; i < lista.Count-1; i++)
            {
                if(lista[i] == lista[i + 1])
                {
                    return false;
                }
            }
            return true;
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

        
    }
}

