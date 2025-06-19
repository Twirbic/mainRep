namespace Lab_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Student");
            Console.WriteLine("2) Car");

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
            Student student = new Student();

            Console.Write("імя студента: ");

            student.Name = Console.ReadLine();

            Console.Write("вік студента: ");


            if (int.TryParse(Console.ReadLine(), out int age))
            {
                student.Age = age;
            }
            else
            {
                Console.WriteLine("Error1");
            }

            Console.WriteLine($"Імя: {student.Name}");
            Console.WriteLine($"Вік: {student.Age}");
        }
    }

    public static class Task2
    {
        public static void Run()
        {

            Car car = new Car();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1 Прискорити");
                Console.WriteLine("2 Згальмувати");
                Console.WriteLine("3 exit");

                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Console.Write("прискорити: ");
                        if (int.TryParse(Console.ReadLine(), out int accelerateAmount))
                        {
                            car.Accelerate(accelerateAmount);
                        }

                        else
                        {
                            Console.WriteLine("Error1");
                        }
                        break;


                    case "2":
                        Console.Write("згальмувати: ");

                        if (int.TryParse(Console.ReadLine(), out int brakeAmount))
                        {
                            car.Brake(brakeAmount);
                        }

                        else
                        {
                            Console.WriteLine("Error2");
                        }
                        break;


                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("wrong choise");
                        break;
                }
            }
        }
    }

    public class Student
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0 && value <= 120)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Error2");
                }
            }
        }
    }

    public class Car
    {
        private int speed;

        public void Accelerate(int amount)
        {
            speed += amount;
            Console.WriteLine($"Швидкість збільшено на {amount}");
        }

        public void Brake(int amount)
        {
            if (amount > speed)
            {
                speed = 0;
                Console.WriteLine("Швидкість встановлена на 0");
            }
            else
            {
                speed -= amount;
                Console.WriteLine($"Швидкість зменшено на {amount}");
            }
        }

        public int Speed
        {
            get { return speed; }
        }
    }
}