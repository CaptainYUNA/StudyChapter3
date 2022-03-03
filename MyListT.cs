using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3.YUNAList2
{
    public class MyList<T> where T : IComparable
    {
        private T[] _array;
        private int _count;

        const int DEFAULT_SIZE = 8;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public int Capacity
        {
            get => _array.Length;
        }

        public int Count
        {
            get => _count;
        }

        public MyList() : this(DEFAULT_SIZE)
        {
            //기본 크기: 8
        }

        public MyList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _array = new T[capacity];
        }

        //Add
        public void Add(T value)
        {
            if (Count == Capacity)
            {
                ExpandCapacity();
            }

            _array[_count] = value;
            _count++;
        }

        internal void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{_array[i]}, ");
            }
            Console.WriteLine();
        }

        //IndexOf: 입력한 값의 index 반환
        public int IndexOf(T value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        //Contains
        public bool Contains(T value)
        {
            return IndexOf(value) > -1;
        }

        //RemoveAt: index + 1에 있는 값 당기기
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index + 1; i < _array.Length; i++)
            {
                _array[i - 1] = _array[i];
            }

            _count--;
        }

        //Insert
        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Capacity == Count)
            {
                ExpandCapacity();
            }

            for (int i = Count; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = value;
            _count++;
        }

        private void ExpandCapacity()
        {
            var tempArray = _array;
            _array = new T[(Capacity == 0 ? 1 : Capacity) * 2];

            Array.Copy(tempArray, 0, _array, 0, tempArray.Length);
        }

        //Clear: 전부 삭제
        public void Clear()
        {
            _count = 0;
        }

        //ToArray
        public T[] ToArray()
        {
            var newArray = new T[Count];

            Array.Copy(_array, 0, newArray, 0, _array.Length);

            return newArray;
        }

        public void Reverse()
        {
            Reverse(0, Count);
        }

        //Reverse
        public void Reverse(int index, int count)
        {
            if (index < 0 || count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count + index > Count)
            {
                throw new ArgumentException();
            }

            Array.Reverse(_array, index, count);
        }
    }
}
