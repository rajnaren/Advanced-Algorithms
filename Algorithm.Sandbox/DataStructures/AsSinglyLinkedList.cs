﻿using System;

namespace Algorithm.Sandbox.DataStructures
{
    //define the generic node
    public class AsSinglyLinkedListNode<T>
    {
        public AsSinglyLinkedListNode<T> Next;
        public T Data;

        public AsSinglyLinkedListNode(T data)
        {
            this.Data = data;
        }
    }

    /// <summary>
    /// A singly linked list implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsSinglyLinkedList<T>
    {
        public AsSinglyLinkedListNode<T> Head;

        //marks this data as the new head
        //cost O(1)
        public void AddFirst(T data)
        {
            var newNode = new AsSinglyLinkedListNode<T>(data);

            newNode.Next = Head;

            Head = newNode;
        }

        //insert at the end
        //costs O(n)
        public void AddLast(T data)
        {
            var newNode = new AsSinglyLinkedListNode<T>(data);

            if (Head == null)
            {
                Head = new AsSinglyLinkedListNode<T>(data);
            }
            else
            {
                var current = Head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

        }

        //cost O(1)
        public void RemoveFirst()
        {
            if (Head == null)
                throw new Exception("Nothing to remove");

            Head = Head.Next;
        }

        //cost O(n)
        public void RemoveLast()
        {
            if (Head == null)
                throw new Exception("Nothing to remove");

            var current = Head;
            AsSinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            prev.Next = null;
        }

        //cost O(n) in worst case O(nlogn) average?
        public void Remove(T data)
        {
            if (Head == null)
                throw new System.Exception("Empty list");

            var current = Head;
            AsSinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Data.Equals(data))
                {
                    //last element
                    if (current.Next == null)
                    {
                        //head is the only node
                        if (prev == null)
                        {
                            Head = null;
                        }
                        else
                        {
                            //last element
                            prev.Next = null;
                        }
                    }
                    else
                    {
                        //current is head
                        if (prev == null)
                        {
                            Head = current.Next;
                        }
                        else
                        {
                            //delete
                            prev.Next = current.Next;
                        }
                    }

                    break;
                }

                prev = current;
                current = current.Next;
            }
            while (current != null);
        }

        //O(n) always
        public int Count()
        {
            var i = 0;
            var current = Head;
            while (current != null)
            {
                i++;
                current = current.Next;
            }

            return i;
        }

        //O(1) always
        public bool IsEmpty()
        {
            return Head == null;
        }

        //O(1) always
        public void RemoveAll()
        {
            if (Head == null)
                throw new System.Exception("Empty list");

            Head = null;
        }

        //O(n) time complexity
        public void PrintAllNodes()
        {
            var current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }


}