using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyLibrary
{
    public class QueueEventHandler<T>
    {
        public string Message { get; }
        public T Item { get; }
        public QueueEventHandler(string message, T item)
        {
            Message = message;
            Item = item;
        }
        public QueueEventHandler(string message)
        {
            Message = message;
        }
    }
}
