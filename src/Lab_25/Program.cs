namespace Lab_25
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Strategy");
            Console.WriteLine("2) Command");
            Console.WriteLine("3) Mediator");
            Console.WriteLine("4) Observer");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1_Strategy.Run();
                    break;
                case "2":
                    Task2_Command.Run();
                    break;
                case "3":
                    Task3_Mediator.Run();
                    break;
                case "4":
                    Task4_Observer.Run();
                    break;
            }
        }
    }

    // Strategy
    public interface ICalculationStrategy
    {
        int Calculate(int a, int b);
    }

    public class AddStrategy : ICalculationStrategy // +
    {
        public int Calculate(int a, int b) => a + b;
    }
    public class SubtractStrategy : ICalculationStrategy // -
    {
        public int Calculate(int a, int b) => a - b;
    }
    public class MultiplyStrategy : ICalculationStrategy // *
    {
        public int Calculate(int a, int b) => a * b;
    }

    public class Calculator
    {
        private ICalculationStrategy _strategy;

        public Calculator(ICalculationStrategy strategy) => _strategy = strategy;
        public void SetStrategy(ICalculationStrategy strategy) => _strategy = strategy;

        public int Execute(int a, int b) => _strategy.Calculate(a, b);
    }


    public static class Task1_Strategy
    {
        public static void Run()
        {
            var calculator = new Calculator(new AddStrategy());

            Console.WriteLine("Choose operation: 1-Add, 2-Subtract, 3-Multiply");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1": calculator.SetStrategy(new AddStrategy()); break;
                case "2": calculator.SetStrategy(new SubtractStrategy()); break;
                case "3": calculator.SetStrategy(new MultiplyStrategy()); break;
            }

            int result = calculator.Execute(5, 4); // NUMBERS HERE
            Console.WriteLine($"Result: {result}");

        }

    }





    //  Command cave comnant
    public interface ICommand
    {
        void Execute();
    }

    public class OpenFileCommand : ICommand
    {
        public void Execute() => Console.WriteLine("File opened.");
    }


    public class SaveFileCommand : ICommand
    {
        public void Execute() => Console.WriteLine("File saved.");
    }


    public class CloseFileCommand : ICommand
    {
        public void Execute() => Console.WriteLine("File closed.");
    }


    public class Editor
    {
        public void RunCommand(ICommand command) => command.Execute();
    }
    

    public static class Task2_Command
    {
        public static void Run()
        {
            var editor = new Editor();
            editor.RunCommand(new OpenFileCommand());
            editor.RunCommand(new SaveFileCommand());
            editor.RunCommand(new CloseFileCommand());
        }
    }



    //  Mediator
    public interface IChatMediator
    {
        void Register(User user);
        void Send(string message, User sender);
    }

    public class ChatMediator : IChatMediator
    {

        private List<User> _users = new List<User>();

        public void Register(User user)
        {
            _users.Add(user);
        }

        public void Send(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                    user.Receive(message);
            }
        }

    }

    public class User
    {
        private string _name;
        private IChatMediator _mediator;

        public User(string name, IChatMediator mediator)
        {
            _name = name;
            _mediator = mediator;
            _mediator.Register(this);
        }

        public void Send(string message)
        {
            Console.WriteLine($"{_name} sends: {message}");
            _mediator.Send(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"{_name} received: {message}");
        }
    }

    public static class Task3_Mediator
    {
        public static void Run()
        {
            var mediator = new ChatMediator();
            var anna = new User("Anna", mediator);
            var oleh = new User("Andry", mediator);
            var maksym = new User("Sasha", mediator);

            anna.Send("Hello!");
        }
    }

    // T Observer
    public interface IObserver
    {
        void Update(string message);
    }



    public class PhoneApp : IObserver
    {

        public void Update(string message)
        {
            Console.WriteLine($"PhoneApp: {message}");
        }
    }

    public class Television : IObserver
    {
        private string _location;
        public Television(string location) => _location = location;

        public void Update(string message)
        {
            Console.WriteLine($"At TV {_location}: {message}");
        }
    }

    public class WeatherStation
    {
        private List<IObserver> _subscribers = new();
        private int _temperature;

        public void Subscribe(IObserver observer)
        {
            _subscribers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _subscribers.Remove(observer);
        }

        public void SetTemperature(int newTemperature)
        {
            if (_temperature != newTemperature)
            {
                _temperature = newTemperature;
                NotifySubscribers($"Зміна погоди: температура {_temperature}C.");
            }
        }

        private void NotifySubscribers(string message)
        {

            foreach (var sub in _subscribers)
            {
                sub.Update(message);
            }

        }
    }

    public static class Task4_Observer
    {
        public static void Run()
        {
            WeatherStation station = new WeatherStation();

            PhoneApp phone1 = new PhoneApp();
            PhoneApp phone2 = new PhoneApp();
            Television board = new Television("1+1");

            station.Subscribe(phone1);
            station.Subscribe(phone2);
            station.Subscribe(board);

            station.SetTemperature(26);
            station.SetTemperature(28); // change the message
            station.SetTemperature(28); 
        }
    }






}
