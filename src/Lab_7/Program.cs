namespace Lab_7
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
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();


        }

        static void Task2()
        {
            int sum = 0;
            int number;

            Console.Write("Enter a num: ");
            number = Convert.ToInt32(Console.ReadLine());

            while (number != 0)
            {
                sum += number;
                Console.Write("Enter a num: ");
                number = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("sum: " + sum);

        }

        static void Task3()
        {
            string password;

            do
            {
                Console.Write("Enter a password: ");
                password = Console.ReadLine();

                if (password != "1234")
                {
                    Console.WriteLine("wrong password");
                }

            } while (password != "1234");

            Console.WriteLine("correct password");


        }

    }
}