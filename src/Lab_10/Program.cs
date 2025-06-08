namespace Lab_10
{
    class MortgageRequest
    {
        public decimal Principal {get; set;}
        public decimal AnnualInterestRate {get; set;}
        public int Years {get; set;}

        public decimal MonthlyPayment
        {
            get
            {
                decimal monthlyRate = AnnualInterestRate / 12 / 100;
                int months = Years * 12;
                if (monthlyRate == 0)
                    return Math.Round(Principal / months, 2);

                decimal factor = (decimal)Math.Pow((double)(1 + monthlyRate), months);
                decimal payment = Principal * monthlyRate * factor / (factor - 1);
                return Math.Round(payment, 2);
            }
        }

        public override string ToString()
        {
            return $"Сума: {Principal:C}, Ставка: {AnnualInterestRate}%, Термін: {Years} років, Платіж: {MonthlyPayment:C}";
        }
    }

    internal class Program
    {
        static Queue<MortgageRequest> queue = new Queue<MortgageRequest>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1) Додати заявку");
                Console.WriteLine("2) Обробити 1шу заявку");
                Console.WriteLine("3) Переглянути першу заявку");
                Console.WriteLine("4) Переглянути всі заявки");
                Console.Write("Оберіть дію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRequest();
                        break;
                    case "2":
                        ProcessRequest();
                        break;
                    case "3":
                        PeekRequest();
                        break;
                    case "4":
                        ViewAllRequests();
                        break;
                    default:
                        Console.WriteLine("Error1");
                        break;
                }
            }
        }


        static void AddRequest()
        {
            try
            {
                Console.Write("Введіть суму кредиту: ");
                decimal principal = decimal.Parse(Console.ReadLine());
                Console.Write("Введіть річну відсоткову ставку: ");
                decimal annualRate = decimal.Parse(Console.ReadLine());
                Console.Write("Введіть термін: ");
                int years = int.Parse(Console.ReadLine());



                var request = new MortgageRequest
                {
                    Principal = principal,
                    AnnualInterestRate = annualRate,
                    Years = years
                };

                queue.Enqueue(request);
                Console.WriteLine("request created");
            }

            catch
            {
                Console.WriteLine("Error2");
            }
        }


        static void ProcessRequest()
        {


            if (queue.Count == 0)
            {
                Console.WriteLine("There is nothing there");
                return;
            }

            var request = queue.Dequeue();
            Console.WriteLine("заявка:");
            Console.WriteLine(request);
        }



        static void PeekRequest()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("There is nothing there");
                return;
            }

            var request = queue.Peek();
            Console.WriteLine("Перша заявка в черзі:");
            Console.WriteLine(request);
        }



        static void ViewAllRequests()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("There is nothing there");
                return;
            }

            Console.WriteLine("Всі заявки в черзі:");
            foreach (var request in queue)
            {
                Console.WriteLine("- " + request);
            }

        }

    }
}
