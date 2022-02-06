using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    public class YUNALinkedList
    {
        public class Node
        {
            public int Data { get; private set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public class LinkedList
        {
            public int Count { get => Count; }
            public Node Head { get; private set; }

            //FindLast
            public Node FindLast()
            {
                var lastNode = Head;

                while (lastNode != null)
                {
                    lastNode = Head.Next;
                }

                return lastNode;
            }

            //AddAfter
            public void AddAfter(int previousData, int newData)
            {
                var preNode = Head;
                var newNode = new Node(newData);

                while (preNode.Data == previousData)
                {
                    preNode.Next = newNode;
                }
            }

            //AddBefore
            public void AddBefore(int previousData, int newData)
            {
                var preNode = Head;
                var newNode = new Node(newData);

                while (preNode.Data == previousData)
                {
                    var nextNode = preNode.Next;

                    preNode.Next = newNode;
                    newNode.Next = nextNode;
                }
            }

            //AddLast
            public void AddLast(int newData)
            {
                var newNode = new Node(newData);
                var head = Head;

                if (head == null)
                {
                    head.Next = newNode;
                }

                var lastNode = FindLast();

                lastNode.Next = newNode;
            }

            //Clear
            //Contains
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
