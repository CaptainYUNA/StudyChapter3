using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    public class YUNAList
    {
        public class List
        {
            private double[] _array;
            private int _count;

            const int DEFAULT_SIZE = 3;

            public double this[int index]
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

            public List() : this(DEFAULT_SIZE)
            {
                //기본 크기: 8
            }

            public List(int capacity)
            {
                if (capacity < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array = new double[capacity];
            }

            //Add
            public void Add(double value)
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
            }

            //IndexOf: 입력한 값의 index 반환
            public int IndexOf(double value)
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i] == value)
                    {
                        return i;
                    }
                }
                return -1;
            }

            //Contains
            public bool Contains(double value)
            {
                return IndexOf(value) > -1;
            }

            //RemoveAt: index + 1에 있는 값 당기기
            public void RemoveAt(int index)
            {
                if (index < 0 || index > Count)
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
            public void Insert(int index, double value)
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
                _array = new double[Capacity * 2];

                Array.Copy(tempArray, 0, _array, 0, tempArray.Length);
            }

            //AddRange
            public void AddRange(int startIndex, int endIndex, double[] values)
            {
                if (values == null)
                {
                    throw new ArgumentNullException();
                }

                if (startIndex < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (endIndex > Count)
                {
                    ExpandCapacity();
                }

                //TODO

            }

            //Clear: 전부 삭제
            public void Clear()
            {
                while (Count < 0)
                {
                    RemoveAt(Count - 1);
                }

                _count = 0;
            }

            //ToArray
            public double[] ToArray()
            {
                var newArray = new double[Count];

                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _array[i];
                }

                return newArray;
            }

            //TODO
            //Reverse
            public List Reverse()
            {
                var newList = new List(Count);


                return newList;
            }
        }
    }
}
