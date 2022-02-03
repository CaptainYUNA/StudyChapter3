using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    public class Chapter3LinkeList
    {
        public class Node
        {
            public int data { get; set; }

            public Node next { get; set; }

            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }

        public class LinkedList
        {
            public Node head;
            public Node GetLastNode()
            {
                Node lastNode = head;
                while (lastNode.next != null)
                {
                    lastNode = lastNode.next;
                }

                return lastNode;
            }

            public void InsertFront(int data)
            {
                Node node = new Node(data);
                node.next = head;
                head = node;
            }

            public void InsertLast(int data)
            {
                Node node = new Node(data);

                if (head == null)
                {
                    head = node;
                    return;
                }

                Node lastNode = GetLastNode();
                lastNode.next = node;
            }

            //pre 뒤에 data 넣기
            public void InsertAfter(int previous, int data)
            {
                Node preNode = null;

                for (Node temp = head; temp != null; temp = temp.next)
                {
                    if (previous == temp.data)
                    {
                        preNode = temp;
                    }
                }

                if (preNode == null)
                {
                    Console.WriteLine($"{previous}는 존재하지 않음");
                    return;
                }

                Node node = new Node(data);
                node.next = preNode.next;
                preNode.next = node;
            }

            public void DeleteNode(int key)
            {
                Node temp = head;
                Node previousNode = null;

                if (temp != null && temp.data == key)
                {
                    head = temp.next;
                    return;
                }

                while (temp != null && temp.data != key)
                {
                    previousNode = temp;
                    temp = temp.next;
                }
                if (temp == null)
                {
                    return;
                }

                previousNode.next = temp.next;
            }

            public void Reverse()
            {
                Node previousNode = null;
                Node currentNode = head;
                Node temp = null;

                while (currentNode != null)
                {
                    temp = currentNode;
                    currentNode.next = previousNode;
                    previousNode = currentNode;
                    currentNode = temp;
                }
            }

            public void Print()
            {

            }
        }
    }
}
