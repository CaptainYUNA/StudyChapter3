using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3.Collection

{
    public class MyCollection<T>
    {
        private T[] array = new T[100];

        public T this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        internal void Print()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
