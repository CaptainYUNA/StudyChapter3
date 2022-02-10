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
                        var nextNode = currentNode.Next;
                        currentNode.Next = newNode;
                        newNode.Next = nextNode;

                        return;
                    }
                }

                while (currentNode.Data != value)
                {
                    currentNode = currentNode.Next;

                    if (currentNode.Data == newValue)
                    {
                        if (currentNode.Next == null)
                        {
                            currentNode.Next = newNode;
                            _count++;

                            return;
                        }
                        else
                        {
                            var nextNode = currentNode.Next;
                            newNode.Next = nextNode;
                            currentNode.Next = newNode;

                            _count++;
                        }
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

                if (currentNode.Data == value && currentNode.Next == null)
                {
                    newNode.Next = currentNode;
                    _count++;

                    return;
                }

                while (currentNode.Data != value)
                {
                    beforeNode = currentNode;
                    currentNode = currentNode.Next;

                    if (currentNode.Next == null)
                    {
                        throw new InvalidOperationException();
                    }
                }

                beforeNode.Next = newNode;
                newNode.Next = currentNode;
                _count++;
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

                while (currentNode.Data != value)
                {
                    count++;
                    currentNode = currentNode.Next;
                }

                if (count == 0)
                {
                    Console.WriteLine("Value not found");
                }

                return count;
            }

            //TODO
            //Remove
            public void Remove(int value)
            {
                var currentNode = _head;
                Node beforeNode = null;

                if (currentNode != null && currentNode.Data == value)
                {
                    _head = currentNode.Next;
                }

                while (currentNode.Data != value)
                {
                    beforeNode = currentNode;
                    currentNode = currentNode.Next;
                }

                if (currentNode.Next != null)
                {
                    beforeNode = currentNode.Next;
                }
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
                var lastNode = FindLast();

                if (lastNode == null)
                {
                    throw new InvalidOperationException();
                }

                if (lastNode.Next == null)
                {
                    _head = null;
                }
                else
                {
                    InternalRemoveNode(lastNode);
                }
            }

            private void InternalRemoveNode(Node node)
            {
                var currentNode = _head;

                while (currentNode.Next.Data != node.Data)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = null;
                _count--;
            }
        }
    }
}
