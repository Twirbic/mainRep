namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }

        static void Task1()
        {
            Console.Write("Введіть число: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("Результат: Число парне.");
            }
            else
            {
                Console.WriteLine("Результат: Число непарне.");
            }
        }

        static void Task2()
        {
            Console.Write("Введіть вашу оцінку: ");
            int score = Convert.ToInt32(Console.ReadLine());

            if (score >= 90 && score <= 100)
            {
                Console.WriteLine("Результат: Ваша оцінка: A");
            }
            else if (score >= 75)
            {
                Console.WriteLine("Результат: Ваша оцінка: B");
            }
            else if (score >= 60)
            {
                Console.WriteLine("Результат: Ваша оцінка: C");
            }
            else if (score >= 0)
            {
                Console.WriteLine("Результат: Ваша оцінка: F");
            }
            else
            {
                Console.WriteLine("Введена оцінка некоректна.");
            }
        }

        static void Task3()
        {
            Console.Write("Введіть число (1-7): ");
            int day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("Понеділок");
                    break;
                case 2:
                    Console.WriteLine("Вівторок");
                    break;
                case 3:
                    Console.WriteLine("Середа");
                    break;
                case 4:
                    Console.WriteLine("Четвер");
                    break;
                case 5:
                    Console.WriteLine("Пятниця");
                    break;
                case 6:
                    Console.WriteLine("Субота");
                    break;
                case 7:
                    Console.WriteLine("Неділя");
                    break;
                default:
                    Console.WriteLine("не є днем неділі");
                    break;
            }
        }

        static void Task4()
        {
            Console.Write("Введіть марку авто: ");
            string brand = Console.ReadLine();

            switch (brand)
            {
                case "Toyota":
                    Console.WriteLine("Японія");
                    break;
                case "BMW":
                    Console.WriteLine("Німеччина");
                    break;
                case "Tesla":
                    Console.WriteLine("США");
                    break;
                default:
                    Console.WriteLine("Невідома марка");
                    break;
            }
        }

        static void Task5()
        {
            Console.Write("Введіть температуру: ");
            int temp = Convert.ToInt32(Console.ReadLine());

            string result = (temp >= 0) ? "Погода тепла" : "Погода холодна"; // if true after ? is used; if false after : used
            Console.WriteLine("Результат: " + result);
        }

        static void Task6()
        {
            try
            {

                Console.Write("Введіть 1ше число: ");
                int a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введіть 2ге число: ");
                int b = Convert.ToInt32(Console.ReadLine());

                int result = a / b;
                Console.WriteLine(result);

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("поділ на 0");
            }
        }
    }
}