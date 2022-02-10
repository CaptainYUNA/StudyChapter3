using System;
using System.Diagnostics;

using static StudyChapter3.YUNALinkedList;

namespace StudyChapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ll = new LinkedList();
            //Console.WriteLine(ll.FindIndex(1));
            //ll.AddAfter(10, 1);
            //Console.WriteLine(ll.FindIndex(1));

            //int[] a = { 10, 45, 23, 5, 212, 65, 1, 2 };

            //PrintArray<int>("a[] :", a);
            //CalcArray<int>(a);

            //LinkedList list = new LinkedList();
            //Random random = new Random();

            //for (int i = 0; i < 5; i++)
            //{
            //    list.InsertLast(random.Next(100));
            //}

            //list.InsertFront(10);
            //list.InsertLast(90);
            //list.InsertAfter(10, 11);
            //list.DeleteNode(90);

            //MyStack<int> stack = new MyStack<int>();

            //for (int i = 0; i < 10; i++)
            //{
            //    int value = random.Next(100);
            //    Console.WriteLine($"Stack Push: {value}");

            //    stack.Push(value);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"Stack Pop: {stack.Pop()}");
            //}

            //int[] array = new int[30];

            var linkedList = new LinkedList();
            var random = new Random();

            Clear(linkedList);

            Initialize(linkedList);
            Check(linkedList, 1, 2, 3, 4);

            // 0개일때, 1개일때, 2개 이상일때,  같은 값이 있을때, 값이 없을때

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
            catch (InvalidOperationException) { }

            linkedList.AddLast(99);
            linkedList.AddAfter(99, 100);
            Check(linkedList, 99, 100);

            linkedList.AddAfter(99, 101);
            Check(linkedList, 99, 101, 100);

            linkedList.AddAfter(100, 102);
            Check(linkedList, 99, 101, 100, 102);

            Clear(linkedList);
            linkedList.AddLast(99);
            linkedList.AddLast(98);
            Check(linkedList, 99, 98);
            Check(linkedList.FindIndex(110), -1);
            Check(linkedList.FindIndex(99), 0);
            Check(linkedList.FindIndex(98), 1);


            linkedList.AddAfter(99, 3);
            linkedList.Print();
            linkedList.AddBefore(99, 2);
            linkedList.Print();



            Clear(linkedList);


            for (int i = 0; i < 5; i++)
            {
                linkedList.AddLast(random.Next(100));
            }

            linkedList.Print();

            linkedList.AddLast(99);
            linkedList.Print();
            linkedList.AddAfter(99, 3);
            linkedList.Print();
            linkedList.AddBefore(99, 2);
            linkedList.Print();
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

        private static void Initialize(LinkedList linkedList)
        {
            Initiaze(linkedList, 1, 2, 3, 4);
        }

        private static void Check(LinkedList list, params int[] values)
        {
            Console.WriteLine($"List: {string.Join(",", values)}");

            var current = list.Head;

            var count = 0;
            Console.Write($"Test: ");
            while (current != null)
            {
                count++;
                Console.Write(current.Data);
                if (current.Next != null)
                {
                    Console.Write(",");
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
