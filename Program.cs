// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text.RegularExpressions;

namespace HelloWorld
{

    class node
    {
        public int val;
        public List<List<int>> lst = new List<List<int>>();
    }

    class Program
    {
        public static List<List<int>> list_in_list = new List<List<int>>();
        public static List<int> new_list = new List<int>();

        public static bool IsNumeric(ref int n)
        {
            try
            {
                Console.Write("Enter an INTEGER: ");
                n = Convert.ToInt32(Console.ReadLine());
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }

        public static int total_convention(int n, List<int> list)
        {
            int total = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    list.Add(i);
                    total += i;
                }
                
            }
            return total;
        }


        public static void merge_list(node f, node a, node b, int val)
        {
            a.lst.ForEach(p => p.Add(val));
            a.lst.ForEach(p => f.lst.Add(p));
            b.lst.ForEach(p => f.lst.Add(p));
        }

        public static void update_list(node f, node a,int val)
        {
            List<List<int>> tmp = new List<List<int>>();
            if (a.lst.Count == 0) //TH bắt đầu 
            {
                List<int> list = new List<int>();
                list.Add(val);
                a.lst.Add(list);
                a.lst.ForEach(p => f.lst.Add(p));
            }
            else
            {
                a.lst.ForEach(p => tmp.Add(p.ToList()));
                tmp.ForEach(p => p.Add(val));
                tmp.ForEach(p => f.lst.Add(p));
            }
        }

        public static int semiPerfect_num(int i, int sum, List<int> list, List<List<int>> f)
        {
            if (i == list.Count)
            {
                //Console.WriteLine("Out: f[" + i +"][" + sum + "]");
                if (sum == 0)
                {
                    return 1;
                }
                return 0;
            }
            if (f[i][sum] != -1)
            {
                /*if (f[i,sum] != 0)
                {
                    new_list.Add(list[i]);
                }*/
                //Console.WriteLine("Da co: f[" + i + "][" + sum + "] = " + f[i, sum]);
                //Console.WriteLine("Have: f[" + i + "(" + list[i] + ")][" + sum + "] = " + f[i, sum]);
                return f[i][sum];
            }
            if (list[i] > sum)
            {
                //Console.WriteLine("Wrong: f[" + i + "(" + list[i] + ")][" + sum + "] = " + f[i, sum]);
                //Console.WriteLine("Vuot dieu kien: f[" + i + "][" + sum + "] = " + f[i, sum]);
                return f[i][sum] = semiPerfect_num(i + 1, sum, list, f);
            }
            //Console.WriteLine("Move: f[" + i + "(" + list[i] + ")][" + sum + "] = " + f[i, sum].val);
            new_list.Add(list[i]);
            int a = semiPerfect_num(i + 1, sum - list[i], list,f);
            if (a != 0)
            {
                list_in_list.Add(new_list);
                new_list = new List<int>(new_list);
                new_list.RemoveAt(new_list.Count - 1);
            }
            else
            {
                new_list = new List<int>(new_list);
                new_list.RemoveAt(new_list.Count - 1);
            }
            int b = semiPerfect_num(i + 1, sum, list,f);
            /*if (a != 0 && b != 0)
            {
                merge_list(f[i, sum], f[i + 1, sum - list[i]], f[i + 1, sum], list[i]);
                *//*Console.WriteLine("After merge: ");
                printTest(f[i, sum].lst, i, sum);*//*

            }
            else if (a != 0)
            {
                *//*printTest(f[6, 12].lst, 6, sum);*//*
                if (i + 1 == list.Count) //TH bắt đầu 
                {
                    List<int> temp = new List<int>();
                    temp.Add(list[i]);
                    f[i, sum].lst.Add(temp);
                    
                }
                else
                {
                    *//*Console.WriteLine("Index: " + i);  *//*
                    update_list(f[i, sum], f[i + 1, sum - list[i]], list[i]);
                }
                *//*Console.WriteLine("After update: ");
                printTest(f[i, sum].lst, i, sum);*//*
            }
            else if(b != 0)
            {
                f[i + 1,sum].lst.ForEach(p => f[i,sum].lst.Add(p));
                *//*Console.WriteLine("After pass: ");
                printTest(f[i, sum].lst, i, sum);*//*
            }*/

            f[i][sum] = a + b;
            //Console.WriteLine("f[" + i + "(" + list[i] + ")][" + sum + "] = " + f[i, sum].val);
            /*Console.WriteLine("F hien tai: ");
            printTest(f, ROW, COL);*/
            /* Console.WriteLine("Add: " + list[i]);*/

            return f[i][sum];
        }

        public static bool isPrime(int x)
        {
            for (int i = 2; i * i <= x; ++i)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return x >= 2;
        }

        public static int totalRes(List<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }

        public static void printTest(List<List<int>> f, int ROW, int COL)
        {
            for(int i = 0; i < ROW; i++)
            {
                for (int  j = 0; j < COL; j++)
                {
                    Console.Write(f[i][j] + " ");
                }
                Console.WriteLine();
            }

        }


        public static void Solving_Problem()
        {
            int n = -1; bool first_con = false; bool sec_con = false;
            do
            {
                first_con = IsNumeric(ref n);
                sec_con = (n >= 1000 && n <= 9999) ? true : false;
            } while (first_con == false || sec_con == false);
            var list_of_convention = new List<int>();
            /*int test = 890;
            int total = total_convention(test, list_of_convention);
            list_of_convention.Sort();
            Console.Write(test + " [");
            foreach (var item in list_of_convention)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine("]");
            int res = semiPerfect_num(0, 0, test, list_of_convention);
            Console.WriteLine(res);*/
            /*int i = 990;*/
            for (int i = 1; i <= n; ++i)
            {
                if (isPrime(i)) {}
                else
                {

                    int total = total_convention(i, list_of_convention);
                    list_of_convention.Sort();
                    if (total == i)
                    {
                        /*Console.WriteLine("Total: " + i);*/
                        Console.Write(i + " [");
                        foreach (var item in list_of_convention)
                        {
                            Console.Write(item + ",");
                        }
                        Console.WriteLine("]");
                    }
                    else
                    {
                        List<int> list = new List<int>(new int[i + 1]);
                        for (int j = 0; j < i + 1; ++j)
                        {
                            list[j] = -1;
                            //Console.Write(list[j] + ",");
                        }
                        //Console.WriteLine();
                        int size = list_of_convention.Count;
                        List<List<int>> f = new List<List<int>>(new List<int>[size]);
                        for (int j = 0; j < size; ++j)
                        {
                            f[j] = new List<int>(list);
                        }
                        //i la tong can 

                        /*Console.WriteLine("F hien tai: ");*/
                        //printTest(f,size,i + 1);

                        int res = semiPerfect_num(0, i, list_of_convention, f);
                        //Console.WriteLine( "Tong tap con: "+ res);
                        bool is_semi = false;
                        int count = 0;
                        //Console.WriteLine("So tap lay duoc: " + f[0, i].lst.Count);
                        /*foreach (var item in f[0, i].lst)
                        {
                            if (totalRes(item) == i)
                            {
                                Console.Write(i + " [");
                                foreach (var item2 in item)
                                {
                                    Console.Write(item2 + ",");
                                }
                                Console.WriteLine("]");
                                is_semi = true;
                            }
                            if (is_semi)
                            {
                                break;
                            }
                        }*/


                        //Console.WriteLine("Count: " + list_in_list.Count);
                        foreach (var item in list_in_list)
                        {
                            Console.Write(i + " [");
                            foreach (var item2 in item)
                            {
                                Console.Write(item2 + ",");
                                is_semi = true;
                            }
                            Console.WriteLine("]");
                            if (is_semi)
                            {
                                break;
                            }
                        }
                        //Console.WriteLine("Tong tap con lay duoc: " + count);
                        new_list.Clear();
                        list_in_list.Clear();
                    }
                    list_of_convention.Clear();
                }
            }
        }
        //Input: int n (has 4 digit)
        //Output: Every number < n within condition:
        //1. Số bán hoàn hảo


        static void Main(string[] args)
        {
            Program.Solving_Problem();
        }
    }
}
