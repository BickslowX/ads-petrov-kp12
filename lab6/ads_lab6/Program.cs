using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ads_lab6
{
    internal class Program
    {
        public class Queue
        {
            private int size, head, tail;
            private List<int> queue = new List<int>();
            private static bool flag = true;
            Queue(int size)
            {
                this.size = size;
                this.head = this.tail = -1;
            }
            public void enQueue(int data)
            {
                if ((head == 0 && tail == size - 1) ||
                  (tail == (head - 1) % (size - 1)))
                {
                    Console.WriteLine("Черга повна ");
                        int prevCount = queue.Count;
                        for (int i = 1; i <= 6; i++)
                        {
                            queue.Add(0);
                            int tmp = queue[head];
                            for (int j = head + 1; j <= queue.Count - 1; j++)
                            {
                                int tmp2 = queue[j];
                                queue[j] = tmp;
                                tmp = tmp2;
                            }
                            queue[head] = -1;
                        head++;
                        size++;
                        }
                    Console.WriteLine("Розмiр черги збiльшено на 6, продовжуйте ");
                }
                else if (head == -1)
                {
                    head = 0;
                    tail = 0;
                    queue.Add(data);
                }

                else if (tail == size - 1 && head != 0)
                {
                    tail = 0;
                    queue[tail] = data;
                }

                else
                {
                    tail = (tail + 1);
                    if (head <= tail)
                    {
                        queue.Add(data);
                    }
                    else
                    {
                        queue[tail] = data;
                    }
                }
            }
            public int deQueue()
            {
                int temp;
                if (head == -1)
                {
                    Console.Write("Черга пуста ");
                    flag = false;
                    return -1;
                }
                temp = queue[head];
                if (head == tail)
                {
                    head = -1;
                    tail = -1;
                }
                else if (head == size - 1)
                {
                    head = 0;
                }
                else
                {
                    head = head + 1;
                }
                return temp;
            }
            public void displayQueue()
            {
                if (head == -1)
                {
                    Console.WriteLine("Черга пуста\n");
                    flag = false;
                    return;
                }
                Console.Write("Черга: ");
                if (tail >= head)
                {
                    for (int i = head; i <= tail; i++)
                    {
                        if (queue[i] != -1)
                        {
                            Console.Write(queue[i]);
                            Console.Write(" ");
                        }
                    }
                    Console.Write("\n");
                }
                else
                {
                    for (int i = head; i < size; i++)
                    {
                        if (queue[i] != -1)
                        {
                            Console.Write(queue[i]);
                            Console.Write(" ");
                        }
                    }
                    for (int i = 0; i <= tail; i++)
                    {
                        if (queue[i] != -1)
                        {
                            Console.Write(queue[i]);
                            Console.Write(" ");
                        }
                    }
                    Console.Write("\n");
                }
            }
            static public void Main()
            {
                Queue q = new Queue(5);
                while(flag == true)
                {
                    Console.WriteLine("\nВведiть значення, яке хочете додати до черги: ");
                    int addValue = Convert.ToInt32(Console.ReadLine());
                    if (addValue == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int x = q.deQueue();
                            if (x != -1)
                            {
                                Console.Write("\nВидалене значення: " + x + "\n");
                                q.displayQueue();
                            }
                        }
                    }
                    else
                    {
                        q.enQueue(addValue);
                        q.displayQueue();
                    }
                }
                Console.WriteLine("\nРобота завершена");
                Console.ReadKey();
            }
        }
    }
}
