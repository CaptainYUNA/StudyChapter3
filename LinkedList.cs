using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3.Collection
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

                if (current.Next != null)
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
            /* LinkedList 구조상 새로운 값을 갖고 있는 newNode를 따로 만들지 않고(변수를 생성하지 않고),
            마지막 노드를 찾았을 때 newNode 변수를 쓰는 것이 불필요한 코드를 줄일 수 있음. 

            AddAfter는 노드를 끝까지 돌면서 Next가 null인 것을 찾고 마지막 노드에 값을 연결하는 것임.
            따라서 while 안의 조건은 모든 Node를 확인할 수 있도록 해야 하는데, 'currentNode.Next != null'를
            조건으로 하면 마지막 노드를 확인하지 않음. 그러므로 while의 조건은 'currentNode != null'로 해야 함

            *** 전체를 돌아야 하는지, 아니면 마지막의 전까지 돌아야 하는지 등 범위를 생각해서 코드를 짜는 것이 중요***
            */

            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data == newValue)
                {
                    break;
                }

                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentException();
            }

            var newNode = new Node(newValue);
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;

            _count++;
        }

        //AddBefore
        //TODO: 위 주의사항 읽어 보고 아래 메소드들 다시 해 보기
        public void AddBefore(int value, int newValue)
        {
            var currentNode = _head;
            Node beforeNode = null;
            var newNode = new Node(newValue);

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    break;
                }

                //어차피 break로 빠져나가니까 else 안 써도 됨
                beforeNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode == null)
            {
                throw new ArgumentException();
            }

            if (beforeNode == null)
            {
                _head = newNode;
            }
            else
            {
                beforeNode.Next = newNode;
                newNode.Next = currentNode;
            }

            _count++;
        }

        //AddLast
        public void AddLast(int newValue)
        {
            var newNode = new Node(newValue);
            var lastNode = FindLast();

            if (lastNode == null)
            {
                _head = newNode;
                /* 여기서 바로 return하지 말고, else 조건을 두고
                _count++는 if와 else 중 하나만 타도 증가하는 것이니 두 번 쓸 필요가 없어짐 */
            }
            else
            {
                lastNode.Next = newNode;
            }

            _count++;
        }

        //Clear
        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        //Contains --> bool
        //참조 0개인 것 놓치지 말기. 검증 필수!
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

        //CopyTo
        public void CopyTo(int[] targetArray, int index)
        {
            if (targetArray == null)
            {
                throw new ArgumentNullException();
            }
            else if (index < 0 || Count < index || index + Count < targetArray.Length)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = _head;

            while (currentNode != null)
            {
                targetArray[index++] = currentNode.Data;
                currentNode = currentNode.Next;
            }
        }

        //FindIndex
        public int FindIndex(int value)
        {
            var currentNode = _head;
            var count = 0;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    return count;
                }

                currentNode = currentNode.Next;
                count++;
            }

            return -1;
        }

        //Remove
        public bool Remove(int value)
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

            if (currentNode.Next == null)
            {
                _head = null;
            }

            _count--;

            return true;
        }

        //RemoveFirst
        public void RemoveFirst()
        {
            _head = _head.Next;
            _count--;
        }

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
            }
            else
            {
                beforeNode.Next = null;
            }

            _count--;
        }
    }
}
