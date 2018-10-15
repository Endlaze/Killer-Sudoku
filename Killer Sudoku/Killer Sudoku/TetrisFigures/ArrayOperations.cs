using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku.TetrisFigures
{
    class ArrayOperations
    {
        public static int [] SumArray (int []array1, int []array2)
        {
            var newArray = array1.Zip(array2, (x, y) => x + y);
            return newArray.ToArray();
        }

        public static int [] SubtractArray(int [] array1, int [] array2)
        {
            var newArray = array1.Zip(array2, (x, y) => x - y);
            return newArray.ToArray();
        }

        public static int[] MultArray(int [] array1, int [] array2)
        {
            var newArray = array1.Zip(array2, (x, y) => x * y);
            return newArray.ToArray();
        } 

        public static int [] MultArrayByMatrix(int [] array, int [,] matrix)
        {
            int[] newArray = new int[array.Length];
            for (int i=0; i< matrix.GetLength(0); i++)
            {
                newArray[i] = MultArray(array, ArrayExt.GetRow(matrix, i)).Sum();
            }
            return newArray;

        }
    }
}