using System;

namespace StudyChapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 10, 45, 23, 5, 212, 65, 1, 2 };

            PrintArray<int>("a[] :", a);
            CalcArray<int>(a);
        }

        private static void CalcArray<T>(T[] array) where T: struct
        {
            T sum = default(T);
            T avg = default(T);
            var max = default(T);

            foreach (dynamic item in array)
            {

            }
        }

        private static void PrintArray<T>(string s, T[] intArray) where T: struct
        {
            Console.Write($"{s}");

            foreach (var intItem in intArray)
            {
                Console.Write($"{intItem}");
            }
        }
    }
}
