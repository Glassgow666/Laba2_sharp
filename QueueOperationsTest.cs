using System;
using System.Collections.Generic;
using Xunit;
using MyLibrary;

namespace XUnitTest
{
    public class QueueOperationsTest
    {
        [Fact]
        public void Task_Add_Element_Test()
        {
            //Arrange
            System.Collections.Generic.Queue<object> TestQueue = new System.Collections.Generic.Queue<object>();
            MyLibrary.Queue<object> MyQueue = new MyLibrary.Queue<object>();
            //Act
            TestQueue.Enqueue(1);
            TestQueue.Enqueue(2);
            TestQueue.Enqueue(3);
            MyQueue.Enqueue(1);
            MyQueue.Enqueue(2);
            MyQueue.Enqueue(3);
            /*foreach (object item in TestQueue)
            {
                foreach(object elem in MyQueue)
                {
                    Assert.Equal(item, elem);
                }
            }*/
            //Assert
            Assert.Equal(TestQueue, MyQueue);
        }

        [Fact]
        public void Task_Get_TheFirstElement_Test()
        {
            //Arrange
            System.Collections.Generic.Queue<object> TestQueue = new System.Collections.Generic.Queue<object>();
            TestQueue.Enqueue(1);
            TestQueue.Enqueue(2);
            TestQueue.Enqueue(3);
            MyLibrary.Queue<object> MyQueue = new MyLibrary.Queue<object>();
            MyQueue.Enqueue(1);
            MyQueue.Enqueue(2);
            MyQueue.Enqueue(3);
            //Act
            object firstitem = TestQueue.Dequeue();
            object firstelem = MyQueue.Dequeue();
            //Assert
            Assert.Equal(firstitem, firstelem);
        }

        [Fact]
        public void Task_Show_TheFirstElement_Test()
        {
            //Arrange
            System.Collections.Generic.Queue<object> TestQueue = new System.Collections.Generic.Queue<object>();
            TestQueue.Enqueue(1);
            TestQueue.Enqueue(2);
            TestQueue.Enqueue(3);
            MyLibrary.Queue<object> MyQueue = new MyLibrary.Queue<object>();
            MyQueue.Enqueue(1);
            MyQueue.Enqueue(2);
            MyQueue.Enqueue(3);
            //Act
            object firstitem = TestQueue.Peek();
            object firstelem = MyQueue.PeekFirst;
            //Assert
            Assert.Equal(firstitem, firstelem);
        }

        [Fact]
        public void Task_ClearQueue_Test()
        {
            //Arrange
            MyLibrary.Queue<object> MyQueue = new MyLibrary.Queue<object>();
            MyQueue.Enqueue(1);
            MyQueue.Enqueue(2);
            MyQueue.Enqueue(3);
            //Act
            MyQueue.Clear();
            //Assert
            Assert.Empty(MyQueue);
        }

        [Fact]
        public void Task_ContainsQueue_Test()
        {
            //Arrange
            MyLibrary.Queue<object> MyQueue = new MyLibrary.Queue<object>();
            //Act
            MyQueue.Enqueue(1);
            MyQueue.Enqueue(2);
            MyQueue.Enqueue(3);
            //Assert
            Assert.Contains(2,MyQueue);
        }
    }
}
