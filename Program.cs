using System;
using MyLibrary;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;
            Queue<object> queue = new Queue<object>();
            queue.ItemChangedNotify += DisplayMessage;
            queue.ItemChangedNotify += DisplayItem;


            Console.Write("Enter the number of items in the queue ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter the value of the queue item ");
                object element = Console.ReadLine();
                queue.Enqueue(element);
            }

            do
            {
                Console.WriteLine("Choose what you want to do");
                Console.WriteLine("1 - add an item to the end of the queue");
                Console.WriteLine("2 - retrieve the first element from the queue");
                Console.WriteLine("3 - return the first item in the queue without removing it");
                Console.WriteLine("4 - return the last item in the queue without removing it");
                Console.WriteLine("5 - clear queue");
                Console.WriteLine("6 - see all elements of the queue");
                Console.WriteLine("7 - check if there is an item in the queue");
                Console.WriteLine("8 - count elements of the queue");
                Console.WriteLine("9 - exit");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.Write("Enter the value of the queue item ");
                        object element = Console.ReadLine();
                        queue.Enqueue(element);
                        //Console.WriteLine("Элемент успешно добавлен");
                        Console.WriteLine();
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine();
                            object firstItem = queue.Dequeue();
                            Console.WriteLine(firstItem);
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Unable to retrieve item from queue because it is empty!");
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine();
                            object firstelem = queue.PeekFirst;
                            Console.WriteLine(firstelem);
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("It is impossible to return the first element of the queue, because it is empty!");
                            Console.WriteLine();
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine();
                            object lastelem = queue.PeekLast;
                            Console.WriteLine(lastelem);
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("It is impossible to return the last element of the queue, because it is empty!");
                            Console.WriteLine();
                        }
                        break;
                    case "5":
                        Console.WriteLine();
                        queue.Clear();
                        //Console.WriteLine("Очередь успешно очищена");
                        Console.WriteLine();
                        break;
                    case "6":
                        Console.WriteLine();
                        Console.WriteLine("All elements of the queue: ");
                        foreach (object item in queue)
                            Console.WriteLine(item);
                        Console.WriteLine();
                        break;
                    case "7":
                        Console.WriteLine();
                        Console.WriteLine("Enter the item you want to check for belonging to the queue");
                        object currentelement = Console.ReadLine();
                        bool a = queue.Contains(currentelement);
                        if (a == true)
                        {
                            Console.WriteLine("Данный элемент присутствует в очереди");
                            Console.WriteLine();
                            foreach (object item in queue)
                                Console.WriteLine(item);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Данный элемент отсутствует в очереди");
                            Console.WriteLine();
                            foreach (object item in queue)
                                Console.WriteLine(item);
                            Console.WriteLine();
                        }
                        break;
                    case "8":
                        Console.WriteLine();
                        Console.WriteLine("Count elements in the queue");
                        int counter = queue.Count;
                        Console.WriteLine(counter);
                        Console.WriteLine();
                        break;
                    case "9":
                        Console.WriteLine();
                        exit = false;
                        break;

                }
            } while (exit);
        }
        private static void DisplayMessage<T>(object sender, QueueEventHandler<T> queueEventHandler)
        {
            Console.WriteLine(queueEventHandler.Message);
        }
        private static void DisplayItem<T>(object sender, QueueEventHandler<T> queueEventHandler)
        {
            Console.WriteLine(queueEventHandler.Item);
        }
    }
}
