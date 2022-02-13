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

                if (currentNode.Next == null)
                {
                    return currentNode;
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
                Node nextNode = null;

                if (currentNode == null)
                {
                    throw new ArgumentNullException();
                }

                if (currentNode.Data == value)
                {
                    if (currentNode.Next == null)
                    {
                        currentNode.Next = newNode;
                        _count++;

                        return;
                    }
                    else
                    {
                        nextNode = currentNode.Next;
                        currentNode.Next = newNode;
                        newNode.Next = nextNode;

                        _count++;

                        return;
                    }
                }
                else
                {
                    while (currentNode.Data != value)
                    {
                        if (currentNode.Data == value)
                        {
                            if (currentNode.Next == null)
                            {
                                currentNode.Next = newNode;
                                _count++;

                                return;
                            }
                            else
                            {
                                nextNode = currentNode.Next;
                                newNode.Next = nextNode;
                                currentNode.Next = newNode;

                                _count++;
                            }
                        }
                        else
                        {
                            currentNode = currentNode.Next;
                        }
                    }

                    if (currentNode.Next == null)
                    {
                        currentNode.Next = newNode;
                        _count++;

                        return;
                    }
                    else
                    {
                        nextNode = currentNode.Next;
                        newNode.Next = nextNode;
                        currentNode.Next = newNode;
                        _count++;

                        return;
                    }

                }
            }

            //AddBefore
            public void AddBefore(int value, int newValue)
            {
                var currentNode = _head;
                var newNode = new Node(newValue);
                Node beforeNode = null;

                if (currentNode == null)
                {
                    throw new ArgumentNullException();
                }

                if (currentNode.Data == value)
                {
                    beforeNode = currentNode;
                    _head = newNode;
                    _head.Next = beforeNode;

                    _count++;

                    return;
                }

                while (currentNode.Data != value)
                {
                    beforeNode = currentNode;
                    currentNode = currentNode.Next;

                    if (currentNode.Next == null)
                    {
                        beforeNode.Next = newNode;
                        newNode.Next = currentNode;
                        _count++;
                    }
                }
            }

            //AddLast
            public void AddLast(int newValue)
            {
                var newNode = new Node(newValue);

                if (_head == null)
                {
                    _head = newNode;
                    _count++;

                    return;
                }

                var currentNode = FindLast();

                currentNode.Next = newNode;
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
                    return false;
                }

                if (currentNode.Data != value && currentNode.Next == null)
                {
                    return false;
                }

                while (currentNode.Data != value)
                {
                    currentNode = currentNode.Next;

                    if (currentNode.Next == null)
                    {
                        return false;
                    }
                }

                return true;
            }

            //CopyTo
            public void CopyTo(int[] targetArray, int index)
            {
                if (targetArray == null)
                {
                    throw new ArgumentNullException();
                }

                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (targetArray.Length < _count)
                {
                    throw new ArgumentException();
                }

                var currentNode = _head;

                if (currentNode == null)
                {
                    throw new ArgumentNullException();
                }

                int _index = 0;

                if (currentNode.Next == null)
                {
                    targetArray[_index] = currentNode.Data;

                    return;
                }

                while (currentNode.Next != null)
                {
                    targetArray[_index++] = currentNode.Data;
                    currentNode = currentNode.Next;
                }
            }

            //TODO
            //FindIndex
            public int FindIndex(int value)
            {
                int count = 0;

                var currentNode = _head;

                if (currentNode == null)
                {
                    return -1;
                }

                if (currentNode.Data == value)
                {
                    return count;
                }

                while (currentNode.Data != value)
                {
                    count++;

                    if (currentNode.Next == null)
                    {
                        return -1;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }

                return count;
            }

            //TODO
            //Remove
            public bool Remove(int value)
            {
                var currentNode = _head;
                Node newNode = null;

                if (currentNode == null)
                {
                    return false;
                }

                if (currentNode.Data == value)
                {
                    if (currentNode.Next == null)
                    {
                        _head = null;
                        _count--;

                        return true;
                    }
                    else
                    {
                        _head = currentNode.Next;
                        _count--;

                        return true;
                    }
                }

                while (currentNode.Data != value)
                {
                    if (newNode == null)
                    {
                        newNode = new Node(currentNode.Data);
                    }
                    else
                    {
                        newNode.Next = new Node(currentNode.Data);
                    }

                    if (currentNode.Next == null)
                    {
                        return false;
                    }

                    currentNode = currentNode.Next;
                }

                _head = newNode;
                currentNode = currentNode.Next;
                AddLast(currentNode.Data);

                return true;
            }

            //TODO
            //RemoveFirst
            public void RemoveFirst()
            {
                _head = _head.Next;
            }

            //TODO
            //RemoveLast
            public void RemoveLast()
            {
                var currentNode = _head;
                Node beforNode = null;

                if (currentNode == null)
                {
                    throw new InvalidOperationException();
                }

                while (currentNode.Next != null)
                {
                    beforNode = currentNode;
                    currentNode = currentNode.Next;
                }

                beforNode.Next = null;
                _count--;
            }
        }
    }
}
