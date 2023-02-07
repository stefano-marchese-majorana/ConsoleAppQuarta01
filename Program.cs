 using System;
using System.Threading;

// (2 * 6) + (1 + 4) * (5 -2)

namespace ConsoleAppThread30
{
    public class MyData
    {
        public static int A;
        public static int B;
        public static int C;
        public static int Result;
    }

    public class MySleep
    {
        public static void Sleep()
        {
            Random rd = new Random();
            int sleep = rd.Next(0, 4) * 1000;
            Thread.Sleep(sleep);
        }
    }

    public class TH
    {
        public static void Method1()
        {
            Console.WriteLine("Method1 is running");
            MyData.A = 2 * 6;
            MySleep.Sleep();
            Console.WriteLine($"A is {MyData.A}");
            Console.WriteLine("Method1 is stopping");
        }

        public static void Method2()
        {
            Console.WriteLine("Method2 is running");
            MyData.B = 1 + 4;
            MySleep.Sleep();
            Console.WriteLine($"B is {MyData.B}");
            Console.WriteLine("Method2 is stopping");
        }

        public static void Method3()
        {
            Console.WriteLine("Method3 is running");
            MyData.C = 5 - 2;
            MySleep.Sleep();
            Console.WriteLine($"C is {MyData.C}");
            Console.WriteLine("Method3 is stopping");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main is running");

            Thread th1 = new Thread(TH.Method1);
            Thread th2 = new Thread(TH.Method2);
            Thread th3 = new Thread(TH.Method3);

            th1.Start();
            th2.Start();
            th3.Start();

            // th2.Join();
            // th3.Join();
            MyData.Result = MyData.B * MyData.C;

            // th1.Join();
            MyData.Result += MyData.A;

            Console.WriteLine($"=== Result {MyData.Result} ===");
            Console.WriteLine("Main is stopping");
        }
    }
}
