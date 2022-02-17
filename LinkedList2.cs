using System;

namespace StudyChapter3.S
{
    public class Node
    {
        public int Data { get; set; }

        public Node Next { get; internal set; }

        public Node(int data)
        {
            Data = data;
        }
    }

    public class LinkedList
    {
        private Node _head;

        public Node Head => _head;

        private int _count;

        public int Count => _count;

        internal void Print()
        {
            var current = _head;

            if (Count == 0)
            {
                Console.WriteLine("List is empty.");
            }

            while (current != null)
            {
                Console.Write(current.Data);

                if (current.Next != null) // 마지막은 안찍기
                {
                    Console.Write(", ");
                }
                current = current.Next;
            }

            Console.WriteLine();
        }

        //FindLast
        public Node FindLast()
        {
            var currentNode = _head;

            if (currentNode == null)
            {
                return null;
            }

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        //AddAfter
        public void AddAfter(int value, int newValue)
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    break;
                }

                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentException("'value' not found.");
            }

            var newNode = new Node(newValue);
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;

            _count++;
        }

        //AddBefore
        public void AddBefore(int value, int newValue)
        {
            var currentNode = _head;
            Node beforeNode = null;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    break;
                }

                beforeNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentException("'value' not found.");
            }

            var newNode = new Node(newValue);
            newNode.Next = currentNode;

            if (beforeNode == null)
            {
                _head = newNode;
            }
            else
            {
                beforeNode.Next = newNode;
            }
            _count++;
        }

        public void AddLast(int newValue)
        {
            var newNode = new Node(newValue);

            var lastNode = FindLast();
            if (lastNode == null)
            {
                _head = newNode;
            }
            else
            {
                lastNode.Next = newNode;
            }
            _count++;
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public bool Contains(int value)
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        public void CopyTo(int[] targetArray, int index)
        {
            // ArgumentNullException: array이(가) null인 경우
            if (targetArray == null)
            {
                throw new ArgumentNullException();
            }
            // ArgumentOutOfRangeException: index가 0보다 작은 경우
            else if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            // ArgumentException: 소스 LinkedList<T>의 요소 수가 대상 array의 index부터 끝까지 사용 가능한 공간보다 큽니다.
            else if (Count > targetArray.Length - index)
            {
                throw new ArgumentException();
            }

            var currentNode = _head;

            while (currentNode != null)
            {
                targetArray[index++] = currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        public int FindIndex(int value)
        {
            var currentNode = _head;
            var index = 0;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    return index;
                }

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }

        public bool Remove(int value)
        {
            Node beforeNode = null;
            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    break;
                }

                beforeNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                return false;
            }

            if (beforeNode == null)
            {
                _head = currentNode.Next;
            }
            else
            {
                beforeNode.Next = currentNode.Next;
            }
            _count--;
            return true;
        }

        public void RemoveFirst()
        {
            _head = _head.Next;
            _count--;
        }

        public void RemoveLast()
        {
            var currentNode = _head;
            Node beforeNode = null;

            if (currentNode == null)
            {
                throw new InvalidOperationException();
            }

            while (currentNode.Next != null)
            {
                beforeNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (beforeNode == null)
            {
                _head = null;
            }
            else
            {
                beforeNode.Next = null;
            }
            _count--;
        }
    }
}