using System;
using System.Collections.Generic;
using static System.Console;
using static System.Console;

namespace ads_lab4_task
{
    class SLList
    {
        public Node head;
        public Node zamena;

        public class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
            }
            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
        public SLList(int data)
        {
            head = new Node(data);
        }
        public SLList()
        {
            head = null;
        }
        public void AddFirst(int data) //+
        {
            Node last = new Node(data);
            last.next = head;
            head = last;
        }
        public void AddToPosition(int data, int position, int count) //+
        {
            if (head == null && position == 1)
            {
                head = new Node(data);
                AddFirst(data);
            }
            else if (position > count)
                AddLast(data);
            else
            {
                Node last = head;
                for (int i = 2; i < position; i++)
                    last = last.next;
                Node addedNode = new Node(data);
                addedNode.next = last.next;
                last.next = addedNode;
            }
        }
        public void AddLast(int data) //+
        {
            if (head == null)
            {
                WriteLine("Список пустий: додано першим");
                AddFirst(data);
            }
            else
            {
                Node last = head;
                while(last.next!=null)
                {
                    last = last.next;
                }
                Node current = new Node(data);
                last.next = current;
                current.next = null;
            }
        }
        public void DeleteFirst() //+
        {
            if (head == null)
                WriteLine("Список пустий");
            else
            {
                Node deletedNode = head;
                head = deletedNode.next;
                deletedNode = null;
            }
        }
        public void DeleteAtPosition(int position, int count) //+
        {
            if (head == null)
                WriteLine("Список пустий");
            else if (position > count)
                DeleteLast();
            else
            {
                Node last = head;
                for (int i = 2; i < position; i++)
                    last = last.next;
                last.next = last.next.next;
                last = null;
            }
        }
        public int CountList() //+
        {
            if (head == null)
            {
                WriteLine("Список пустий");
                return 0;
            }
            else
            {
                int count = 0;
                Node last = head;
                while (last.next != null)
                {
                    last = last.next;
                    count++;
                }
                count++;
                return count;
            }
        }
        public void Task(int data)
        {
            int counter = 0;
            while (counter != (int)CountList() / 2)
                counter++;
            if (head == null && counter == 1)
            {
                head = new Node(data);
                AddFirst(data);
            }
            else
            {
                Node current = head;
                for (int i = 2; i <= counter; i++)
                    current = current.next;
                Node addedNode = new Node(data);
                addedNode.next = current.next;
                current.next = addedNode;
            }

        }
        public void DeleteLast() //+
        {
            Node last = head;
            while (last.next.next != null)
            {
                last = last.next;
            }
            last.next = null;
        }
        public void Print() //+
        {
            if (head == null)
                WriteLine("Список пустий");
            else
            {
                Node last = head;
                while (last.next!=null)
                {
                    Write(last.data + ", ");
                    last = last.next;
                }
                WriteLine(last.data + ".");
            }
        }
        public SLList RandomGen(int quant) //+
        {
            SLList list = new SLList();
            Random rnd = new Random();
            if (quant <= 0)
                return list;
            head = new Node(rnd.Next(5, 100));
            for (int i = 1; i < quant; i++)
                AddLast(rnd.Next(5, 100));
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;
            Write("Оберіть розмір списку: ");
                int size = Convert.ToInt32(ReadLine());
                SLList list = new SLList();
                list.RandomGen(size);
                WriteLine("Сгенерований список: ");
                list.Print();
            int choice;
            int repeater = 0;
            do
            {
                WriteLine("\t\tМЕНЮ");
                WriteLine("1. Додавання нового вузла у голову списку");
                WriteLine("2. Додавання нового вузла у хвіст списку");
                WriteLine("3. Додавання нового вузла на визначену позицію");
                WriteLine("4. Видалення голови списку");
                WriteLine("5. Видалення хвоста списку");
                WriteLine("6. Видалення вузла з визначеної позиції");
                WriteLine("7. Виведення вмісту списку");
                WriteLine("8. Додавання нового вузла перед середнім вузлом списку");
                choice = Convert.ToInt32(Console.ReadLine());
                Clear();
                if(choice==1)
                {
                    WriteLine("Введіть значення:");
                    list.AddFirst(Convert.ToInt32(ReadLine()));
                    list.Print();
                }
                if (choice == 2)
                {
                    WriteLine("Введіть значення:");
                    list.AddLast(Convert.ToInt32(ReadLine()));
                    list.Print();
                }
                if (choice == 3)
                {
                    WriteLine("Введіть номер позиції: ");
                    int i = Convert.ToInt32(ReadLine());
                    WriteLine("Введіть значення:");
                    list.AddToPosition(Convert.ToInt32(ReadLine()),i, list.CountList());
                    list.Print();
                }
                if (choice == 4)
                {
                    list.DeleteFirst();
                    list.Print();
                }
                if (choice == 5)
                {
                    list.DeleteLast();
                    list.Print();
                }
                if (choice == 6)
                {
                    WriteLine("Введіть номер позиції: ");
                    int i = Convert.ToInt32(ReadLine());
                    list.DeleteAtPosition(i,list.CountList());
                    list.Print();
                }
                if (choice == 7)
                {
                    list.Print();
                }
                if (choice == 8)
                {
                    WriteLine("Введіть значення: ");
                    int i = Convert.ToInt32(ReadLine());
                    list.Task(i);
                    list.Print();
                }
            } while (repeater == 0);
        }
    }
}
