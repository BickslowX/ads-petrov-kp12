using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ads_lab5
{
    internal class Program
    {
        static int[] array;
        public static void Main()
        {
            Console.WriteLine("Inpun n"); int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inpun m"); int m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            int[,] arr = new int[n, m];
            Random r = new Random();
            for(int i = 0;i<n; i++)
            {
                for(int j = 0;j<m; j++)
                {
                    arr[i, j] = r.Next(10, 100);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j + 1) % 2 != 0 && (i + 1) % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(arr[i, j]+"\t");
                }
                Console.WriteLine();
            }
            int c1 = 0;
            array = new int[n*m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j+1) % 2 != 0 && (i+1) % 2 == 0)
                    {
                        array[c1] = arr[i, j];
                        c1++;
                    }
                }
            }
            sort();
            Console.WriteLine("\n");
            int c2 = array.Length-1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j + 1) % 2 != 0 && (i + 1) % 2 == 0)
                    {
                        arr[i, j] = array[c2];
                        c2--;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void sort()
        {
            int n = array.Length;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            int[] output = new int[n];
            int[] count = new int[max+1];

            for (int i = 0; i < max + 1; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                count[array[i]]++;
            }
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                count[array[i]]--;
            }
            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }

        }
    }
}
