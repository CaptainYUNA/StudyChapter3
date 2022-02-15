﻿using System;
using System.Diagnostics;

using static StudyChapter3.YUNALinkedList;
using static StudyChapter3.YUNAList;

namespace StudyChapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList
            var linkedList = new LinkedList();

            Initialize(linkedList);
            Check(linkedList, 1, 2, 3, 4);

            // 0개일 때, 1개일 때, 2개 이상일 때, 같은 값이 있을 때, 값이 없을 때

            Clear(linkedList);
            linkedList.AddLast(99);
            Check(linkedList, 99);

            linkedList.AddLast(99);
            Check(linkedList, 99, 99);

            Clear(linkedList);
            linkedList.AddLast(99);
            linkedList.AddLast(98);
            Check(linkedList, 99, 98);


            Clear(linkedList);

            try
            {
                linkedList.AddAfter(99, 100);
                Error();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("List is empty.");
            }

            linkedList.AddLast(99);
            linkedList.AddAfter(99, 100);
            Check(linkedList, 99, 100);

            linkedList.AddAfter(99, 101);
            Check(linkedList, 99, 101, 100);

            try
            {
                linkedList.AddAfter(100, 102);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Value not found.");
            }

            Check(linkedList, 99, 101, 100, 102);

            Clear(linkedList);
            linkedList.AddLast(99);
            linkedList.AddLast(98);
            Check(linkedList, 99, 98);

            //var test = linkedList.FindIndex(110);
            //Q. 값 비교하는 Check 함수를 안 보는 이유? 두 번째 매개변수가 하나라서인지?
            CheckIndex(linkedList.FindIndex(110), -1);
            CheckIndex(linkedList.FindIndex(99), 0);
            CheckIndex(linkedList.FindIndex(98), 1);

            linkedList.AddAfter(99, 3);
            linkedList.Print();
            linkedList.AddBefore(99, 2);
            linkedList.Print();

            Clear(linkedList);
            linkedList.Print();

            linkedList.AddLast(99);
            linkedList.Print();
            linkedList.AddAfter(99, 3);
            linkedList.Print();
            //TODO
            linkedList.AddBefore(99, 2);
            linkedList.Print();

            linkedList.RemoveFirst();
            linkedList.Print();
            try
            {
                linkedList.RemoveLast();
            }
            catch (ArgumentException)
            {
            }

            linkedList.Print();

            linkedList.Clear();
            linkedList.AddLast(2);
            linkedList.Print();
            linkedList.AddLast(99);
            linkedList.Print();
            linkedList.AddAfter(2, 7);
            linkedList.Print();
            //TODO: AddBefore 중간 값을 찾아서 넣는 것 다시
            linkedList.AddBefore(99, 11);
            linkedList.Print();
            linkedList.AddBefore(99, 33);
            linkedList.Print();

            linkedList.Remove(11);
            linkedList.Print();

            if (!linkedList.Remove(10))
            {
                Console.WriteLine("Value not found.");
            }

            //List
            var list = new List();
            list.Add(3.3);
            list.Add(5.5);
            list.Add(7.7);
            list.Add(9.9);
            list.Add(11.1);
            list.Print();
            Console.WriteLine();

            list.Add(17.7);
            list.Add(19.9);
            list.Add(21.1);
            list.Print();
            var count = list.Count;
            Console.WriteLine();
            Console.WriteLine($"List Length: {count}");

            var index = list.IndexOf(17.7);
            Console.WriteLine($"Expected index = 5 / IndexOf: {index}");
            index = list.IndexOf(99);
            Console.WriteLine($"Expected index = -1 / IndexOf: {index}");
            list.RemoveAt(4);
            list.Print();
            Console.WriteLine();

            try
            {
                list.RemoveAt(77);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Out of range");
            }

            list.Print();
            Console.WriteLine();
            list.Reverse();
            list.Print();
            Console.WriteLine();

            list.Insert(4, 12.3);
            list.Print();
            Console.WriteLine();

            try
            {
                list.Insert(77, 54.2);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Out of range");
            }

            var array = list.ToArray();

            if (array.Length == list.Count)
            {
                Console.WriteLine("O");
            }
            else
            {
                Console.WriteLine("X");
            }
        }

        private static bool CheckIndex(int v1, int v2)
        {
            if (v1 == v2)
            {
                return true;
            }
            else
            {
                Error();
                return false;
            }
        }

        private static void Check(int v1, int v2)
        {
            Console.WriteLine("X");
            Error();
        }

        private static void Error()
        {
            Debugger.Break();
        }

        private static void Initialize(LinkedList list)
        {
            Initiaze(list, 1, 2, 3, 4);
        }

        private static void Check(LinkedList list, params int[] values)
        {
            Console.WriteLine($"List: {string.Join(",", values)}");

            var current = list.Head;

            var count = 0;

            Console.Write($"Method Test: ");

            while (current != null)
            {
                count++;
                Console.Write(current.Data);
                if (current.Next != null)
                {
                    Console.Write(", ");
                }
                current = current.Next;
            }

            Console.WriteLine();

            if (count != values.Length)
            {
                Console.WriteLine("X");
                Error();
                return;
            }

            if (list.Count != values.Length)
            {
                Console.WriteLine("X");
                Error();
                return;
            }

            var index = 0;
            current = list.Head;

            while (current != null)
            {
                if (current.Data != values[index++])
                {
                    Console.WriteLine("X");
                    Error();
                    return;
                }
                current = current.Next;
            }

        }

        private static void Initiaze(LinkedList list, params int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                list.AddLast(values[i]);
            }
        }

        private static void Clear(LinkedList list)
        {
            list.Clear();
            list.Count = 0;
        }


        //private static void CalcArray<T>(T[] array) where T : struct
        //{
        //    T sum = default(T);
        //    T avg = default(T);
        //    var max = default(T);

        //    foreach (dynamic item in array)
        //    {

        //    }
        //}

        //private static void PrintArray<T>(string s, T[] intArray) where T : struct
        //{
        //    Console.Write($"{s}");

        //    foreach (var intItem in intArray)
        //    {
        //        Console.Write($"{intItem}");
        //    }
        //}
    }
}
