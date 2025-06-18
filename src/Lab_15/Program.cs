using System.Diagnostics;

namespace Lab_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Parallel Invoke");
            Console.WriteLine("2) Race Condition");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1.Run();
                    break;
                case "2":
                    Task2.Run();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }

    public static class Task1
    {
        public static void Run()
        {
            Console.WriteLine("1. Вивід чисел від 1 до 500");
            Console.WriteLine("2. Обчислення факторіалу числа 10");

            Stopwatch stopwatch = Stopwatch.StartNew();

            Parallel.Invoke(
                () => PrintNumbers(),
                () => CalculateFactorial(10)
            );

            stopwatch.Stop();
            Console.WriteLine($"⏳ Час виконання: {stopwatch.ElapsedMilliseconds} мс");
        }

        static void PrintNumbers()
        {
            Console.WriteLine("Друк чисел:");
            for (int i = 1; i <= 500; i++)
            {
                Console.Write($"{i} ");
                if (i % 25 == 0) Console.WriteLine();
            }
        }

        static long CalculateFactorial(int n)
        {
            Console.WriteLine($"Обчислення факторіалу {n}");
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
                Thread.Sleep(50);
            }
            Console.WriteLine($"Факторіал {n} = {result}");
            return result;
        }
    }





    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine("Потокобезпека Race Condition:");
            DemonstrateRaceCondition();
            
            Console.WriteLine("Lock:");
            DemonstrateWithLock();
        }

        static void DemonstrateRaceCondition() // неправильний варіант
        {
            int counter = 0;
            Parallel.For(0, 1000, i =>
            {
                counter++; 
            });
            Console.WriteLine($"Результат без захисту: {counter} з 1000");
        }

        static void DemonstrateWithLock() // правильний варіант
        {
            int counter = 0;
            object lockObj = new object();
            
            Parallel.For(0, 1000, i =>
            {
                lock (lockObj)
                {
                    counter++;
                }
            });
            Console.WriteLine($"Результат з lock: {counter}");
        }

    }
}