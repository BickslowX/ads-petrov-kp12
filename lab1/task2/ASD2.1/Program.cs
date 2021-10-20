using System;
using static System.Console;
using static System.Math;


namespace task_2
{
    class Program
    {
        static void Main()
        {
            WriteLine("Введiть d1:");
            int d1 = int.Parse(ReadLine());
            WriteLine("Введiть d2:");
            int d2 = int.Parse(ReadLine());
            WriteLine("Введiть m1:");
            int m1 = int.Parse(ReadLine());
            WriteLine("Введiть m2:");
            int m2 = int.Parse(ReadLine());
            WriteLine("Введiть y1:");
            int y1 = int.Parse(ReadLine());
            WriteLine("Введiть y2:");
            int y2 = int.Parse(ReadLine());
            int[] Month = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (m1<=Month.Length&&m2<=Month.Length&&d1<=Month[m1]&&d2<=Month[m2])
            {
                bool leapyear(int a)
                {
                    if (a % 4 == 0 && a % 100 != 0)
                    {
                        return true;
                    }
                    else if (a % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                int summ1 = 0, summ2 = 0;
                //рахуємо кiлькiсть днiв до нового року
                for (int i = m1 - 1; i < 12; i++) 
                {
                    if (leapyear(y1))
                    {
                        Month[1] = 29; 
                    }  //якщо високосний рiк, у 2 мiсяцi буде 29 днiв
                    else 
                    { 
                        Month[1] = 28; 
                    }
                    summ1 += Month[i];      //сума днiв в наступних вiд m1 мiсяцях
                }
                for (int i = 1; i < m2 - 1; i++)
                {
                    if (leapyear(y2))
                    {
                        Month[1] = 29; 
                    }
                    else 
                        Month[1] = 28;
                    summ2 += Month[i];    //сума днiв в наступних вiд m2 мiсяцях
                }
                int k = 0;
                if (leapyear(y1))  //у високосний рiк виводило на 1 день бiльше
                    if (y1 == y2)
                    {
                        k = 1;
                    }
                int s = Month[m1 - 1] - d1 + d2 + summ1 + summ2 - k;
                int j = 0;
                for (int i = y1 + 1; i <= y2 - 1; i++)
                {
                    if (i % 4 == 0 && i % 100 != 0)
                    {
                        j++; 
                    }
                    else if (i % 400 == 0) 
                    {
                        j++;
                    }
                }
                Write("Кiлькiсть днiв: ");

                int days = s + 366 * j + 365 * (y2 - 1 - y1 - j);
                WriteLine(days);
                int years = 0;
                if (m2 > m1)
                {
                    years = y2 - y1;
                }
                else
                {
                    if (m2 == m1 && d2 >= d1)
                    {
                        years = y2 - y1;
                    }
                    else
                    { 
                        years = y2 - y1 - 1;
                    }
                }
                Console.WriteLine("Номер повних рокiв: " + years);
            }
            else
                Console.WriteLine("Некоректна дата");
        }
    }
}