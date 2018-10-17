using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Killer_Sudoku.TetrisFigures;

namespace Killer_Sudoku
{
    public static class ArrayExt
    {
        //Get row from a matrix
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
                throw new InvalidOperationException("Not supported for managed types.");

            if (array == null)
                throw new ArgumentNullException("array");

            int cols = array.GetUpperBound(1) + 1;
            T[] result = new T[cols];
            int size = Marshal.SizeOf<T>();

            Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

            return result;
        }

        //Print array
        public static void PrintArray(int [] array)
        {
            Console.WriteLine(string.Join(", ", array.Select(element => element.ToString())));
        }

        //Print matrix
        public static void Print2DArray<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        //Init int array

        public static int [,] InitIntMatrix(int size)
        {
            int[,] newArray = new int [size,size];
            for (int i=0; i< size; i++)
            {
                for (int j=0; j<size; j++)
                {
                    newArray[i, j] = 0;
                }
            }
            return newArray;
        }



    }
}


