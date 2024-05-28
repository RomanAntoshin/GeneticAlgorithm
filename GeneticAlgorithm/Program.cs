using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tests = Directory.GetFiles("E:\\ННГУ им Лобачевского\\Диплом версия на середину марта\\Тесты");
            string[] buf = new string[tests.Length];
            MergeSort(tests, buf, 0, tests.Length-1);
            for(int i=0; i<tests.Length; i++)
                for(int j=0; j<tests.Length; j++)
                    if(tests[i].Length==tests[j].Length && String.Compare(tests[i], tests[j])==-1)
                    {
                        string buf1 = tests[i];
                        tests[i] = tests[j];
                        tests[j] = buf1;
                    }
            Random rnd = new Random();
            for (int i= 0; i<tests.Length; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                double[,] data = Reader.GetData(tests[i]);
                Console.WriteLine(tests[i]);
                int correct = (int)(Math.Sqrt(data.Length)/10)%3;
                int size = Math.Max((int)Math.Sqrt(data.Length), 48);
                if (size != 48)
                    size = size - correct;
                Person[] first_group = new Person[size];
                GetFirstGroup(first_group, data);
                int N = 200;
                if (Math.Sqrt(data.Length) > 1000)
                    N = 1000;
                else
                    N = Math.Max(200, (int)Math.Sqrt(data.Length));
                IBriding briding = new Briding_OX();
                Console.WriteLine("Start: " + first_group[GetBestPersonAt(first_group)].Criteria);
                stopwatch.Start();
                for (int j = 0; j < N; j++)
                {
                    /*if (j == N - 1 || j == 0)
                    {
                        int ind = GetBestPersonAt(first_group);
                        Console.WriteLine("Best - " + first_group[ind].Criteria);
                        Console.WriteLine(j);
                    }*/
                    AStrategy str = new Panmixia(briding, data, first_group);
                    str.Iteration();
                }
                stopwatch.Stop();
                Console.WriteLine("Finish: " + first_group[GetBestPersonAt(first_group)].Criteria);
                Console.WriteLine("Time: "+stopwatch.ElapsedMilliseconds);
                Console.WriteLine("-------------");
            }
            Console.Beep(600, 1000);
        }

        static void MergeSort(string[] tests, string[] buf, int left, int right)
        {
            int mid;
            if(left<right)
            {
                mid = (left + right) / 2;
                MergeSort(tests, buf, left, mid);
                MergeSort(tests, buf, mid + 1, right);
                int k = left;
                for(int i=left, j=mid+1; i<=mid ||j<=right;)
                {
                    if(j>right||(i<=mid && tests[i].Length<tests[j].Length))
                    {
                        buf[k] = tests[i];
                        ++i;
                    }
                    else
                    {
                        buf[k] = tests[j];
                        ++j;
                    }
                    ++k;
                }
                for (int i = left; i <= right; ++i)
                    tests[i] = buf[i];
            }
        }
        static void GetFirstGroup(Person[] first_group, double[,] data)
        {
            Algorithm[] algorithms = new Algorithm[first_group.Length];
            Random rnd = new Random();
            for (int i = 0; i < algorithms.Length / 3; i++)
                algorithms[i] = new NearestNeighborAlgorithm(data, rnd.Next(0, (int)Math.Sqrt(data.Length)));
            for (int i = algorithms.Length / 3; i < 2 * algorithms.Length / 3; i++)
                algorithms[i] = new NearestCityAlgorithm(data, rnd.Next(0, (int)Math.Sqrt(data.Length)));
            for (int i = 2 * algorithms.Length / 3; i < algorithms.Length; i++)
                algorithms[i] = new WoodenAlgorithm(data, rnd.Next(0, (int)Math.Sqrt(data.Length)));
            for (int i = 0; i < algorithms.Length; i++)
            {
                first_group[i] = algorithms[i].GiveSolution();
            }

        }
        static int GetBestPersonAt(Person[] group)
        {
            double min = group[0].Criteria;
            int ind = 0;
            for (int i = 1; i < group.Length; i++)
            {
                if (group[i].Criteria < min)
                {
                    min = group[i].Criteria;
                    ind = i;
                }
            }
            return ind;
        }
    }
}
