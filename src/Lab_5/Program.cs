namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
        static void Task1()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(IsEven(num));
        }

        static bool IsEven(int number)
        {

            return number % 2 == 0;

        }

        static void Task2()
        {
            Console.WriteLine(Sum(5, 13));
            Console.WriteLine(Sum(6, 4));    
            Console.WriteLine(Sum(2.5, 3.4));  
            
        }

        
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sum(int a, int b, int c) 
        {
            return a + b + c;
        }

        static double Sum(double a, double b) 
        {
            return a + b;
        }


        static void Task3()
        {
            int a = 5, b = 10;

            int temp = a;
            a = b;
            b = temp;

            Console.WriteLine($"a = {a}, b = {b}"); 
        }

        static void NumChange(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

    }
}
