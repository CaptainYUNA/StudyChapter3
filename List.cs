using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    public class YUNAList
    {
        public class List : IEnumerable<double>
        {
            private double[] _array;
            private int _count;

            public int Capacity
            {
                get
                {
                    return _array.Length;
                }
            }

            public int Count
            {
                get
                {
                    return _count;
                }
            }

            public List()
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

            }

            public IEnumerator<double> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            //IndexOf

            //Contains

            //RemoveAt

            //Insert

            //AddRange

            //Clear

            //ToArray

            //Reverse
        }
    }
}
