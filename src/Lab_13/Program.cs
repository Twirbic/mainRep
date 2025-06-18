namespace Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) делегат та предикат");
            Console.WriteLine("2) зміна статусу");

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


    class Task1
    {
        public static void Run()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            Predicate<int> isEven = n => n % 2 == 0;
            int[] evenNumbers = Filter(numbers, isEven);

            Console.WriteLine("Парні числа:");
            foreach (int num in evenNumbers)
            {
                Console.WriteLine(num);
            }
        }

        private static int[] Filter(int[] numbers, Predicate<int> predicate)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }
    }
    
    


    class Task2
    {
        public static void Run()
        {
            Order order = new Order();

            order.OrderStatusChanged += OrderStatusChangedHandler;

            order.Status = "Отримано";
            order.Status = "Відправлено";
            order.Status = "Доставлено";
        }

        private static void OrderStatusChangedHandler(object sender, string status)
        {
            Console.WriteLine($"Статус замовлення змінено на: {status}");
        }

        class Order
        {
            public event EventHandler<string> OrderStatusChanged;

            private string status;

            public string Status
            {
                get => status;
                set
                {
                    if (status != value)
                    {
                        status = value;
                        OnOrderStatusChanged(status);
                    }
                }
            }

            protected virtual void OnOrderStatusChanged(string status)
            {
                OrderStatusChanged?.Invoke(this, status);
            }
        }
    }

}
