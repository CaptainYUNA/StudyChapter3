using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3
{
    public static class LinkedList
    {
        public static Node head;

        internal static void InserFront(int data)
        {
            var node = new Node(data);
            node.next = head;
            head = node;
        }

        internal static void InsertLast(int data)
        {
            var node = new Node(data);

            if (head == null)
            {
                head = node;
                return;
            }

            var lastNode = GetLastNode();
        }

        internal static void InsertAfter(int previous, int data)
        {
            Node previousNode = null;

        }

        private static Node GetLastNode()
        {
            var tempNode = head;
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }

            return tempNode;
        }

        public class Node
        {
            public int data { get; set; }
            public Node next;
            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }
    }
}
