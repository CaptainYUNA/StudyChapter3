using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    [System.Runtime.InteropServices.Guid("3935E801-FA0C-4C1C-88A6-4C707E21B2B0")]
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 10, 45, 23, 5, 212, 65, 1, 2 };

            PrintArray<int>("a[] :", a);
            CalcArray<int>(a);
            Console.WriteLine(FindMax<int>(a));
        }

        public static T? FindMax<T>(T[] items) where T : struct, IComparable<T>
        {
            T? max = null;

            for (int i = 0; i < items.Length; i++)
            {
                if (max == null)
                {
                    max = items[i];
                }
                else if (items[i].CompareTo(max.Value) > 0)
                {
                    max = items[i];
                }
            }
            return max;
        }



        private static void CalcArray<T>(T[] array) where T : struct
        {
            T sum = default(T);
            T avg = default(T);
            var max = default(T);

            foreach (dynamic item in array)
            {

            }
        }

        private static void PrintArray<T>(string s, T[] intArray) where T : struct
        {
            Console.Write($"{s}");

            foreach (var intItem in intArray)
            {
                Console.Write($"{intItem}");
            }
        }
    }
}
