using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ads_lab2
{
    class Program
    {
        static int[,] MatrixGen(int n, int a)
        {
            
            int t = 0;
            int[,] matrix = new int[n, n];
            if (a == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = t;
                        t++;
                    }
                }
            }
            if(a==1)
            {
                Random r = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = r.Next(0,1000);
                    }
                }
            }
            return matrix;
        }
        static void print(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Write(matrix[i, j]+"\t");
                }
                WriteLine();
            }
        }
        static void Main(string[] args)
        {
            WriteLine("Enter the dimension of the matrix ");
            int n = Convert.ToInt32(ReadLine());
            WriteLine("\nEnter the number of the matrix filling method: \n 0) Test\n 1) Random");
            int a = Convert.ToInt32(ReadLine());
            int[,] mat;
            if(a!=0&&a!=1)
            {
                WriteLine("\nInvalid method number");
                ReadKey();
                return;
            }
            mat = MatrixGen(n,a);
            WriteLine();
            print(mat, n);
            int t = 1;
            WriteLine();
            int u = 0, u1 = 0,u2=0;
            int mu = 999999999, mu1 = 0, mu2 = 0;
            //upper
            while (t <= n - 1)
            {
                if (t % 2 == 0)
                {
                    for (int i = 0; i < t; i++)
                    {
                        WriteLine(mat[i, n - 1 - t]);
                        if(u< mat[i, n - 1 - t])
                        {
                            u = mat[i, n - 1 - t];
                            u1 = i;
                            u2 = n - 1 - t;
                        }
                        if(mu > mat[i, n - 1 - t])
                        {
                            mu = mat[i, n - 1 - t];
                            mu1 = i;
                            mu2 = n - 1 - t;
                        }
                    }
                }
                else
                {
                    for (int i = t-1; i >=0; i--)
                    {
                        WriteLine(mat[i, n - 1 - t]);
                        if (u < mat[i, n - 1 - t])
                        {
                            u = mat[i, n - 1 - t];
                            u1 = i;
                            u2 = n - 1 - t;
                        }
                        if (mu > mat[i, n - 1 - t])
                        {
                            mu = mat[i, n - 1 - t];
                            mu1 = i;
                            mu2 = n - 1 - t;
                        }
                    }
                }
                t++;
            }
            //diagonal
            for (int i = 0; i < n; i++)
            {
                WriteLine(mat[n - 1 - i, i]);
            }
            int l = 0, l1=0, l2=0;
            int ml = 999999999, ml1 = 0, ml2 = 0;
            //lower
            t = 1;
            while (t <= n - 1)
            {
                if (t % 2 == 0)
                {
                    for (int i = 0; i < t; i++)
                    {
                        WriteLine(mat[t, n-t+i ]);
                        if (l < mat[t, n - t + i])
                        {
                            l = mat[t, n - t + i];
                            l1 = t;
                            l2 = n - t + i;
                        }
                        if (ml > mat[t, n - t + i])
                        {
                            ml = mat[t, n - t + i];
                            ml1 = t;
                            ml2 = n - t + i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < t; i++)
                    {
                        WriteLine(mat[t, n-1-i ]);
                        if (l < mat[t, n - 1 - i])
                        {
                            l = mat[t, n - 1 - i];
                            l1 = t;
                            l2 = n - 1 - i;
                        }
                        if (ml > mat[t, n - 1 - i])
                        {
                            ml = mat[t, n - 1 - i];
                            ml1 = t;
                            ml2 = n - 1 - i;
                        }
                    }
                }
                t++;
            }
            WriteLine($"\n Maximum element above the side diagonal: [{u1+1}, {u2+1}] = {u}");
            WriteLine($" Minimum element above the side diagonal: [{mu1+1}, {mu2+1}] = {mu}");
            WriteLine($"\n Maximum element under the side diagonal: [{l1+1}, {l2+1}] = {l}");
            WriteLine($" Minimum element under the side diagonal: [{ml1+1}, {ml2+1}] = {ml}");
            ReadKey();
        }
    }
}


