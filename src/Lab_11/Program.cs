using System.Text.RegularExpressions;

namespace Lab_11
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
                    SupportTicketSystem.Run();
                    break;
                case "2":
                    WordAnalyzer.Run();
                    break;
                default:
                    Console.WriteLine("Read");
                    break;
            }
        }
    }
    // MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM

    public static class SupportTicketSystem
    {
        private static Queue<string> ticketQueue = new Queue<string>();

        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("обробка заявок:");
                Console.WriteLine("1) додати заявку");
                Console.WriteLine("2) обробити заявку");
                Console.WriteLine("3) подивитися 1шу заявку");
                Console.WriteLine("4) показати всі заявки");
                Console.Write("Виберіть опцію: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTicket();
                        break;
                    case "2":
                        ProcessTicket();
                        break;
                    case "3":
                        ViewFirstTicket();
                        break;
                    case "4":
                        ShowAllTickets();
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void AddTicket()
        {
            Console.Write("Введіть текст: ");
            string ticket = Console.ReadLine();
            ticketQueue.Enqueue(ticket);
            Console.WriteLine("SuccesS");
        }

        private static void ProcessTicket()
        {
            if (ticketQueue.Count > 0)
            {
                string ticket = ticketQueue.Dequeue();
                Console.WriteLine($"Заявка обробленнаЖ {ticket}");
            }
            else
            {
                Console.WriteLine("There is nothing there");
            }
        }

        private static void ViewFirstTicket()
        {
            if (ticketQueue.Count > 0)
            {
                string ticket = ticketQueue.Peek();
                Console.WriteLine($"1 заявка в черзі: {ticket}");
            }
            else
            {
                Console.WriteLine("There is nothing there");
            }
        }

        private static void ShowAllTickets()
        {
            if (ticketQueue.Count == 0)
            {
                Console.WriteLine("There is nothing there");
                return;
            }

            Console.WriteLine("Заявки в черзі:");
            int counter = 1;
            foreach (var ticket in ticketQueue)
            {
                Console.WriteLine($"{counter}. {ticket}");
                counter++;
            }
        }
    }

    public static class WordAnalyzer
    {
        public static void Run()
        {
            Console.WriteLine("Аналізатор тексту");
            Console.WriteLine("Введіть текст:");

            while (true)
            {
                string inputText = Console.ReadLine();


                if (inputText.ToLower() == "exit")
                    break;


                if (string.IsNullOrWhiteSpace(inputText))
                {
                    Console.WriteLine("Error");
                    continue;
                }

                AnalyzeText(inputText);
            }
        }

        private static void AnalyzeText(string inputText)
        {

            var words = Regex.Split(inputText.ToLower(), @"[^\w']+") //  
                             .Where(word => !string.IsNullOrEmpty(word));

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();



            foreach (string word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            var sortedWords = wordCounts.OrderByDescending(pair => pair.Value);

            foreach (var pair in sortedWords)
            {
                Console.WriteLine($"\"{pair.Key}\": {pair.Value} разів");
            }
            Console.WriteLine();

            
        }
    }
}