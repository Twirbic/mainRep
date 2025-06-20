namespace Lab_24
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Adapter");
            Console.WriteLine("2) Facade");
            Console.WriteLine("3) Decorator");

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
        }
    }

    public static class Task1
    {
        public static void Run()
        {
            var oldPrinter = new OldPrinter();
            INewPrinter printer = new PrinterAdapter(oldPrinter);
            printer.Print("done");
        }
    }

    public static class Task2
    {
        public static void Run()
        {
            var car = new CarFacade();
            car.StartCar();
        }
    }

    public static class Task3
    {
        public static void Run()
        {
            IWriter writer = new TimestampWriter(new ConsoleWriter());
            writer.Write("done2");
        }
    }






    #region Adapter Pattern Classes 
    public interface INewPrinter
    {
        void Print(string message);
    }

    public class OldPrinter
    {

        public void OldPrint()
        {
            Console.WriteLine("Printing from old printer...");
        }
    }


    public class PrinterAdapter : INewPrinter
    {
        private readonly OldPrinter _oldPrinter;


        public PrinterAdapter(OldPrinter oldPrinter)
        {
            _oldPrinter = oldPrinter;
        }

        public void Print(string message)
        {
            Console.WriteLine($"Adapting: {message}");
            _oldPrinter.OldPrint();
        }

    }

    #endregion






    #region Facade Pattern Classes
    public class Engine
    {
        public void Start()
        {
            Console.WriteLine("Engine started");
        }

    }

    public class Battery
    {
        public void Start()
        {
            Console.WriteLine("Battery powered");
        }

    }


    public class IgnitionSystem
    {
        public void Start()
        {
            Console.WriteLine("Ignition system is ready");
        }

    }

    public class CarFacade
    {
        private readonly Engine _engine;
        private readonly Battery _battery;
        private readonly IgnitionSystem _ignition;

        public CarFacade()
        {
            _engine = new Engine();
            _battery = new Battery();
            _ignition = new IgnitionSystem();
        }

        public void StartCar()
        {
            _battery.Start();
            _ignition.Start();
            _engine.Start();
            Console.WriteLine("Car is ready");
        }



    }
    #endregion







    #region Decorator Pattern Classes
    public interface IWriter
    {
        void Write(string text);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);

        }

    }

    public class TimestampWriter : IWriter
    {

        private readonly IWriter _inner;

        public TimestampWriter(IWriter inner)
        {
            _inner = inner;
        }

        public void Write(string text)
        {
            string stamped = $"[{DateTime.Now:hh:mm:ss}] {text}";
            _inner.Write(stamped);

        }
    }

    #endregion

}
