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

            public Node()
            {
                Data = default;
                Next = null;
            }
        }

        public class LinkedList
        {
            private Node head;

            public Node GetHead()
            {
                return head;
            }

            private void SetHead(Node value)
            {
                head = value;
            }

            //FindLast
            /// <summary>
            /// LinkedList에서 마지막 Node를 가져온다.
            /// </summary>
            /// <returns></returns>
            public Node FindLast()
            {
                var lastNode = GetHead();

                if (lastNode == null)
                {
                    var node = new Node();
                    SetHead(node);

                    return node;
                }

                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                return lastNode;
            }

            //AddAfter
            /// <summary>
            /// LinkedList에서 Node 중 입력한 값을 갖고 있는 노드를 찾은 후 해당 노드의 다음 노드가 있을 시 
            /// 연결을 해제하고 새로운 노드를 추가한 뒤 연결 해제한 노드를 재연결한다.
            /// </summary>
            /// <param name="value">찾을 값</param>
            /// <param name="newValue">새로 추가할 값</param>
            public void AddAfter(int value, int newValue)
            {
                var head = GetHead();
                var newNode = new Node(newValue);

                while (head.Data != value)
                {
                    head = head.Next;
                }

                if (head.Next == null)
                {
                    head.Next = newNode;
                }
                else
                {
                    var nextNode = head.Next;
                    newNode.Next = nextNode;
                    head.Next = newNode;
                }
            }

            //AddBefore
            /// <summary>
            /// LinkedList의 Node 중 입력한 값을 갖고 있는 노드를 찾은 후 이전 노드와의 연결을 해제 후
            /// 새로운 Node를 이전 노드와 연결하고 새로운 Node에 기존 노드를 연결한다.
            /// </summary>
            /// <param name="value">찾을 값</param>
            /// <param name="newValue">새로 추가할 값</param>
            public void AddBefore(int value, int newValue)
            {
                var head = GetHead();
                var newNode = new Node(newValue);
                Node beforeNode = new Node();

                while (head.Data != value)
                {
                    beforeNode = head;
                    head = head.Next;
                }

                beforeNode.Next = newNode;
                newNode.Next = head;
            }

            //AddLast
            /// <summary>
            /// LinkedList의 마지막 노드에 새로운 Node를 추가한다.
            /// </summary>
            /// <param name="newValue">새로 추가할 값</param>
            public void AddLast(int newValue)
            {
                var newNode = new Node(newValue);

                var lastNode = FindLast();

                if (lastNode.Data == 0)
                {
                    lastNode.Data = newValue;
                }
                else
                {
                    lastNode.Next = newNode;
                }
            }

            //Clear
            //Contains --> bool 
            //CopyTo
            //Find
            //Remove
            //RemoveFirst
            //RemoveLast
        }
    }


    //public class Chapter3LinkeList
    //{
    //    public class Node
    //    {
    //        public int data { get; set; }

    //        public Node next { get; set; }

    //        public Node(int data)
    //        {
    //            this.data = data;
    //            next = null;
    //        }
    //    }

    //    public class LinkedList
    //    {
    //        public Node head;
    //        public Node GetLastNode()
    //        {
    //            Node lastNode = head;
    //            while (lastNode.next != null)
    //            {
    //                lastNode = lastNode.next;
    //            }

    //            return lastNode;
    //        }

    //        public void InsertFront(int data)
    //        {
    //            Node node = new Node(data);
    //            node.next = head;
    //            head = node;
    //        }

    //        public void InsertLast(int data)
    //        {
    //            Node node = new Node(data);

    //            if (head == null)
    //            {
    //                head = node;
    //                return;
    //            }

    //            Node lastNode = GetLastNode();
    //            lastNode.next = node;
    //        }

    //        //pre 뒤에 data 넣기
    //        public void InsertAfter(int previous, int data)
    //        {
    //            Node preNode = null;

    //            for (Node temp = head; temp != null; temp = temp.next)
    //            {
    //                if (previous == temp.data)
    //                {
    //                    preNode = temp;
    //                }
    //            }

    //            if (preNode == null)
    //            {
    //                Console.WriteLine($"{previous}는 존재하지 않음");
    //                return;
    //            }

    //            Node node = new Node(data);
    //            node.next = preNode.next;
    //            preNode.next = node;
    //        }

    //        public void DeleteNode(int key)
    //        {
    //            Node temp = head;
    //            Node previousNode = null;

    //            if (temp != null && temp.data == key)
    //            {
    //                head = temp.next;
    //                return;
    //            }

    //            while (temp != null && temp.data != key)
    //            {
    //                previousNode = temp;
    //                temp = temp.next;
    //            }
    //            if (temp == null)
    //            {
    //                return;
    //            }

    //            previousNode.next = temp.next;
    //        }

    //        public void Reverse()
    //        {
    //            Node previousNode = null;
    //            Node currentNode = head;
    //            Node temp = null;

    //            while (currentNode != null)
    //            {
    //                temp = currentNode;
    //                currentNode.next = previousNode;
    //                previousNode = currentNode;
    //                currentNode = temp;
    //            }
    //        }

    //        public void Print()
    //        {

    //        }
    //    }
    //}
}
