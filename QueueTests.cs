using MyLibrary;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections;

namespace QueueTests
{
    [TestFixture]       
    public class QueueTests
    {
        Queue<int> myQueue;
        Queue<int> emptyQueue;

        [SetUp]
        public void Setup()
        {
            myQueue = new Queue<int>();
            emptyQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
        }

        [TestCase(4)]
        public void Enqueue_ValidValue4_ReturnCount4(int item)
        {
            int expectedCount = 4;

            myQueue.Enqueue(item);
            int actualCount = myQueue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Dequeue_QueueIsEmpty_InvalidOperationExceptionExpected()
        {
            Assert.Throws<InvalidOperationException>(()=>emptyQueue.Dequeue());
        }

        [Test]
        public void Dequeue_QueueWithHead1_Return1()
        {
            int expectedHead = 1;

            int actualHead = myQueue.Dequeue();

            Assert.AreEqual(expectedHead, actualHead);
        }

        [Test]
        public void PeekFirst_QueueIsEmpty_InvalidOperationExceptionExpected()
        {
            Assert.Throws<InvalidOperationException>(() => { int firstElem = emptyQueue.PeekFirst; });
        }

        [Test]
        public void PeekFirst_QueueWithFirstItem1_Return1()
        {
            int expectedFirstElement = 1;

            int actualFirstElement = myQueue.PeekFirst;

            Assert.AreEqual(expectedFirstElement, actualFirstElement);
        }

        [Test]
        public void PeekLast_QueueIsEmpty_InvalidOperationExceptionExpected()
        {
            Assert.Throws<InvalidOperationException>(() => { int lastElem = emptyQueue.PeekLast; });
        }

        [Test]
        public void PeekLast_QueueWithLastItem3_Return3()
        {
            int expectedLastElement = 3;

            int actualLastElement = myQueue.PeekLast;

            Assert.AreEqual(expectedLastElement, actualLastElement);
        }

        [Test]
        public void Clear_ClearQueueWithElements_Count0Expected()
        {
            int expectedCount = 0;

            myQueue.Clear();
            int actualCount = myQueue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(1,true)]
        [TestCase(100,false)]
        public void Contains_ContainsElementInQueue_ReturnResult(int item, bool result)
        {
            Assert.AreEqual(result, myQueue.Contains(item));
        }

        [TestCase(4,"Item 4 added")]
        public void EventItemChangedNotify_EnqueueElement_MessageExpected(int item, string message)
        {
            string actual = null;

            myQueue.ItemChangedNotify += (object sender, QueueEventHandler<int> handler) => { actual = handler.Message; };
            myQueue.Enqueue(item);

            Assert.AreEqual(message,actual);
        }

        [Test]
        public void Count_CountElementsInQueue3_ReturnResult3()
        {
            int expectedCount = 3;

            int actualCount = myQueue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(4)]
        public void EventItemChangedNotify_EnqueueElement_ItemExpected(int item)
        {
            int actual = 0;

            myQueue.ItemChangedNotify += (object sender, QueueEventHandler<int> handler) => { actual = handler.Item; };
            myQueue.Enqueue(item);

            Assert.AreEqual(item, actual);
        }

        [Test]
        public void EventItemChangedNotify_EnqueueElement_CorrectSenderExpected()
        {
            object actual = null;
            object expected = myQueue;

            myQueue.ItemChangedNotify += ( sender,  handler) => { actual = sender; };
            myQueue.Enqueue(2);

            Assert.AreSame(expected, actual);
        }
    }
}