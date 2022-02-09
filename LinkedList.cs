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
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public class LinkedList
        {
            private Node _head;

            private int _count;

            public int Count
            {
                get
                {
                    return _count;
                }
                set
                {
                    while (_head.Next != null)
                    {
                        _count++;
                    }
                }
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

                while (currentNode.Data != value)
                {
                    currentNode = currentNode.Next;
                }

                if (currentNode.Next == null)
                {
                    currentNode.Next = newNode;
                }
                else
                {
                    var nextNode = currentNode.Next;
                    newNode.Next = nextNode;
                    currentNode.Next = newNode;
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
                    _head = newNode;

                }

                while (currentNode.Data != value)
                {
                    beforeNode = currentNode;
                    currentNode = currentNode.Next;
                }

                beforeNode.Next = newNode;
                newNode.Next = currentNode;
            }

            //AddLast
            public void AddLast(int newValue)
            {
                var newNode = new Node(newValue);

                var currentNode = FindLast();

                if (currentNode == null)
                {
                    currentNode = newNode;
                }

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;
            }

            //Clear
            public void Clear()
            {
                _head = null;
            }

            //Contains --> bool 
            public bool Contains(int value)
            {
                var currentNode = FindLast();

                if (currentNode == null)
                {
                    return false;
                }

                while (currentNode.Data != value)
                {
                    currentNode = currentNode.Next;

                    return true;
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

                if (index < 0 || index > targetArray.Length)
                {
                    throw new ArgumentException();
                }

                if (targetArray.Length - index < Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var currentNode = _head;

                if (currentNode == null)
                {
                    return;
                }

                int _index = 0;

                while (currentNode.Next != null)
                {
                    targetArray[_index++] = currentNode.Data;
                    currentNode = currentNode.Next;
                }
            }

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

            //RemoveFirst
            public void RemoveFirst()
            {
                _head = _head.Next;
            }

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
