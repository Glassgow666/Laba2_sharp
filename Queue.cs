using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLibrary
{
    public class Queue<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public delegate void ChangedQueueDelegate(object sender, QueueEventHandler<T> queueEventHandler);
        public ChangedQueueDelegate ItemChangedNotify;

        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
            {
                head = tail;
            }

            else
                tempNode.Next = tail;

            count++;
            ItemChangedNotify?.Invoke(this,new QueueEventHandler<T>($"Item {data} added",data));
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            ItemChangedNotify?.Invoke(this, new QueueEventHandler<T>($"The item has been removed from the queue: {output}", output));
            return output;
        }

        public T PeekFirst
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;

            }
        }

        public T PeekLast
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;

            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
            ItemChangedNotify?.Invoke(this, new QueueEventHandler<T>($"The queue is cleared, amount of elements = {count}"));
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        private class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }
    }
}
