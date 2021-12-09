using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace adsLab3
{
    class Program
    {
        static int n;
        static int m;
        static int[,] a;
        static void Main(string[] args)
        {
            Random r = new Random();
            WriteLine("Input number of rows"); n = Convert.ToInt32(Console.ReadLine());
            WriteLine("Input number of collumns"); m = Convert.ToInt32(Console.ReadLine());
            a = new int[n, m];
            int bol = 0;
            WriteLine("\n Default:\n");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int f = r.Next(10, 100);
                    for (int z = 0; z < n; z++)
                    {
                        for (int x = 0; x < m; x++)
                        {
                            if (f == a[z, x])
                            {
                                bol = 1;
                            }
                        }
                    }
                    if(bol==0)
                    {
                        a[i, j] = f;
                    }
                    else
                    {
                        j--;
                        bol = 0;
                    }
                }
            }
            print(a);
            Sort(a);
            WriteLine("\n Sorted: \n");
            print(a);
            ReadKey();
        }
        static void print(int[,] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i < j) && (i + j != n - 1))
                    {
                        BackgroundColor = ConsoleColor.DarkBlue;
                        Write(a[i, j] + "\t");
                    }
                    else
                    {
                        BackgroundColor = ConsoleColor.Black;
                        Write(a[i, j] + "\t");
                    }
                }
                WriteLine();

            }
        }
        static int Sort(int[,] a)
        {
            int count = 0;
            for (int w = 0; w < n; w++)
            {
                for (int s = w + 1; s < n; s++)
                {
                    int q = w, r = s, min = 100;
                    for (int i = w; i < n; i++)
                    {
                        for (int j = s; j < n; j++)
                        {
                            count++;
                            if (i < j && i + j != n - 1)
                            {
                                count++;
                                if (a[i, j] < min)
                                {
                                    min = a[i, j]; q = i; r = j;
                                }
                            }
                        }
                    }
                    for (int i = w + 1; i < n; i++)
                    {
                        for (int j = s + 1; j < n; j++)
                        {
                            count++;
                            if (i < j && i + j != n - 1)
                            {
                                count++;
                                if (a[i, j] < min)
                                {
                                    min = a[i, j]; q = i; r = j;
                                }
                            }
                        }
                    }
                    if (w + s != n - 1)
                    {
                        count++;
                        int temp = a[w, s];
                        a[w, s] = a[q, r];
                        a[q, r] = temp;
                    }
                }
            }

            return count++;
        }
    }
}
