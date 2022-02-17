using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3.Collection
{

    public class MyStack<T>
    {
        const int size = 10;

        public T[] array = new T[size];

        public int top;

        public MyStack()
        {
            top = 0;
        }

        public void Push(T value)
        {
            if (top < size)
            {
                array[top] = value;
                ++top;
            }
            else
            {
                Console.WriteLine("Stack Full");
            }
        }

        public T Pop()
        {
            if (top > 0)
            {
                --top;
                return array[top];
            }
            else
            {
                return default(T);
            }
        }
    }
}
