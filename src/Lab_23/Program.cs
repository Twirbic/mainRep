namespace Lab_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Singleton");
            Console.WriteLine("2) Factory Method");
            Console.WriteLine("3) Builder");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1.Run();
                    break;
                case "2":
                    Task2.Run();
                    break;
                case "3":
                    Task3.Run();
                    break;
            }
            Console.ReadKey(); // exit
        }
    }

    // Singleton 
    public static class Task1
    {
        public static void Run()
        {

            Logger.Instance.Log("Перший лог");
            Logger.Instance.Log("Другий лог");

            var logger1 = Logger.Instance;
            var logger2 = Logger.Instance;
            Console.WriteLine($"{ReferenceEquals(logger1, logger2)}");
        }
    }

    public sealed class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private Logger() { }



        public static Logger Instance
        {
            get
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }

            }
        }

        public void Log(string msg)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {msg}");
        }
    }


    // Завдання 2: Factory Method 
    public static class Task2
    {
        public static void Run()
        {
            Console.Write("Введіть тип (email/sms/push): ");
            string type = Console.ReadLine();

            try
            {

                INotification notification = NotificationFactory.Create(type);
                notification.Send("Нове повідомлення");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Надіслано email: {message}");
    }


    public class SMSNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Надіслано SMS: {message}");
    }


    public class PushNotification : INotification
    {
        public void Send(string message) => Console.WriteLine($"Надіслано push: {message}");
    }


    public class NotificationFactory
    {
        public static INotification Create(string type)
        {
            return type.ToLower() switch // send face notif
            {
                "email" => new EmailNotification(),
                "sms" => new SMSNotification(),
                "push" => new PushNotification(),
                _ => throw new ArgumentException("Error2")
            };
        }
    }

    // Завдання 3: Builder 
    public static class Task3
    {
        public static void Run()
        {
            Console.WriteLine("Створення кастомного компютера:");
            Console.Write("Введіть процесор: ");
            string cpu = Console.ReadLine();
            Console.Write("Введіть відеокарту: ");
            string gpu = Console.ReadLine();
            Console.Write("Введіть об'єм RAM (GB): ");
            int ram = int.Parse(Console.ReadLine());
            Console.Write("Введіть об'єм SSD (GB): ");
            int ssd = int.Parse(Console.ReadLine());

            var customPC = new ComputerBuilder()
                .SetCPU(cpu)
                .SetGPU(gpu)
                .SetRAM(ram)
                .SetSSD(ssd)
                .Build();
            Console.WriteLine("Ваша конфігурація:");
            Console.WriteLine(customPC);
        }
    }

    public class Computer
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public int RAM { get; set; } // in GB
        public int SSD { get; set; } // gb

        public override string ToString()
        {
            return $"Компютерна конфігурація: Процесор: {CPU}\n Відеокарта: {GPU}\n Оперативна пам'ять: {RAM}GB\n SSD накопичувач: {SSD}GB";
        }
    }

    public class ComputerBuilder
    {
        private Computer _computer = new Computer();

        public ComputerBuilder SetCPU(string cpu)
        {
            _computer.CPU = cpu;
            return this;
        }

        public ComputerBuilder SetGPU(string gpu)
        {
            _computer.GPU = gpu;
            return this;
        }

        public ComputerBuilder SetRAM(int ram)
        {
            _computer.RAM = ram;
            return this;
        }

        public ComputerBuilder SetSSD(int ssd)
        {
            _computer.SSD = ssd;
            return this;
        }

        public Computer Build()
        {
            return _computer;
        }
    }
}