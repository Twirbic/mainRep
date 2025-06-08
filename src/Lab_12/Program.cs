namespace Lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) обробка заявок");
            Console.WriteLine("2) аналізатор тексту");

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
                    Console.WriteLine("Read");
                    break;
            }
        }
    }
    // MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
    public struct Point
    {
        public double X {get;}
        public double Y {get;}
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString() => $"({X}, {Y})";
    }

    public static class Task1
    {
        public static void Run()
        {

            var p1 = new Point(3, 4);
            var p2 = new Point(0, 0);

            Console.WriteLine($"Точка 1: {p1}");
            Console.WriteLine($"Точка 2: {p2}");
            Console.WriteLine($"Відстань між точками: {p1.DistanceTo(p2)}");

            Console.WriteLine("Створення власних точок:");
            Console.Write("Введіть x1: ");

            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть y1: ");

            double y1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть x2: ");

            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Введіть y2: ");

            double y2 = double.Parse(Console.ReadLine());

            var userP1 = new Point(x1, y1);
            var userP2 = new Point(x2, y2);

            Console.WriteLine($"Tочки: {userP1} і {userP2}");
            Console.WriteLine($"Відстань між точкaми: {userP1.DistanceTo(userP2)}");
        }
    }

    // Car
    public class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public int? Year { get; }
        public string Color { get; }

        public Car(string brand, string model)
        {
            Brand = brand;
            Model = model;
            Year = null;
            Color = "Unknown";
        }

        public Car(string brand, string model, int year) : this(brand, model)
        {
            Year = year;
        }

        public Car(string brand, string model, int year, string color) : this(brand, model, year)
        {
            Color = color;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Інформація про автомобіль:");
            Console.WriteLine($"Марка: {Brand}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine(Year.HasValue ? $"Рік випуску: {Year}" : "Рік випуску: Unknown");
            Console.WriteLine($"Колір: {Color}");
        }
    }

    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine("Automobils");

            var cars = new List<Car>
            {
                new Car("Toyota", "Corolla"),
                new Car("Honda", "Civic", 2020),
                new Car("Ford", "Mustang", 2022, "Червоний")
            };

            Console.WriteLine("Створені автомобілі:");
            foreach (var car in cars)
            {
                car.ShowInfo();
            }

            Console.WriteLine("Створення автомобіля:");
            Console.Write("Введіть марку: ");

            var brand = Console.ReadLine();
            Console.Write("Введіть модель: ");

            var model = Console.ReadLine();
            Console.Write("Введіть рік випуску: ");

            var yearInput = Console.ReadLine();
            Console.Write("Введіть колір: ");

            var color = Console.ReadLine();

            Car userCar;
            if (int.TryParse(yearInput, out int year))
            {

                if (!string.IsNullOrWhiteSpace(color))
                    userCar = new Car(brand, model, year, color);
                else
                    userCar = new Car(brand, model, year);
            }

            else
            {
                userCar = new Car(brand, model);
            }

            userCar.ShowInfo();
        }
    }
}