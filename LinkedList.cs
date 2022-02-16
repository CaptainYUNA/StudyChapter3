using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    public class YUNALinkedList
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

            public int Count
            {
                get
                {
                    return _count;
                }
                internal set
                {
                    _count = value;
                }
            }

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
                    Console.Write(", ");
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
                var newNode = new Node(newValue);

                if (currentNode == null)
                {
                    throw new ArgumentNullException();
                }

                while (currentNode.Next != null)
                {
                    if (currentNode.Data == value)
                    {
                        var nextNode = currentNode.Next;
                        currentNode.Next = newNode;
                        newNode.Next = nextNode;

                        _count++;

                        return;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }

                if (currentNode.Data == value)
                {
                    currentNode.Next = newNode;
                    _count++;

                    return;
                }

                throw new ArgumentException();
            }

            //AddBefore
            public void AddBefore(int value, int newValue)
            {
                var currentNode = _head;
                Node beforeNode = null;
                var newNode = new Node(newValue);

                if (currentNode == null)
                {
                    throw new ArgumentException();
                }

                if (currentNode.Data == value)
                {
                    var nextNode = currentNode;
                    _head = newNode;
                    newNode.Next = nextNode;

                    _count++;

                    return;
                }

                while (currentNode.Next != null)
                {
                    if (currentNode.Data == value)
                    {
                        beforeNode.Next = newNode;
                        newNode.Next = currentNode;
                        _count++;

                        return;
                    }
                    else
                    {
                        beforeNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                }

                if (beforeNode == null)
                {
                    throw new InvalidOperationException();
                }

                beforeNode.Next = newNode;
                newNode.Next = currentNode;
                _count++;

                return;

            }

            //AddLast
            public void AddLast(int newValue)
            {
                var currentNode = _head;
                var newNode = new Node(newValue);

                if (currentNode == null)
                {
                    _head = newNode;
                    _count++;

                    return;
                }

                var lastNode = FindLast();

                lastNode.Next = newNode;
                _count++;
            }

            //Clear
            public void Clear()
            {
                _head = null;
            }

            //Contains --> bool 
            public bool Contains(int value)
            {
                var currentNode = _head;

                if (currentNode == null)
                {
                    throw new ArgumentNullException();
                }

                while (currentNode.Next != null)
                {
                    if (currentNode.Data == value)
                    {
                        return true;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }

                return false;
            }

            //CopyTo
            public void CopyTo(int[] targetArray, int index)
            {
                var currentNode = _head;

                if (currentNode == null)
                {
                    throw new ArgumentException();
                }

                if (currentNode.Next == null)
                {
                    targetArray[index] = currentNode.Data;

                    return;
                }

                while (currentNode.Next != null)
                {
                    targetArray[index++] = currentNode.Data;
                    currentNode = currentNode.Next;
                }

            }

            //TODO
            //FindIndex
            public int FindIndex(int value)
            {
                var currentNode = _head;
                var count = 0;

                if (currentNode == null)
                {
                    throw new ArgumentException();
                }

                while (currentNode.Next != null)
                {
                    if (currentNode.Data == value)
                    {
                        return count;
                    }
                    else
                    {
                        count++;
                        currentNode = currentNode.Next;
                    }
                }

                if (currentNode.Data == value)
                {
                    return count;
                }

                return -1;
            }

            //TODO
            //Remove
            public bool Remove(int value)
            {
                var currentNode = _head;
                Node beforeNode = null;

                if (currentNode == null)
                {
                    throw new InvalidOperationException();
                }

                if (currentNode.Data == value)
                {
                    if (currentNode.Next == null)
                    {
                        _head = null;
                        _count--;
                    }
                }

                while (currentNode.Next != null)
                {
                    if (currentNode.Data == value)
                    {
                        beforeNode.Next = currentNode.Next;
                        _count--;

                        return true;
                    }
                    else
                    {
                        beforeNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                }

                return false;
            }

            //TODO
            //RemoveFirst
            public void RemoveFirst()
            {
                _head = _head.Next;
                _count--;
            }

            //TODO
            //RemoveLast
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
                    _count--;
                }
                else
                {
                    beforeNode.Next = null;
                    _count--;
                }
            }
        }
    }
}
