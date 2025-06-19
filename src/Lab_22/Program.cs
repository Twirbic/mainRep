using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lab_22
{
    public interface IGreetingService
    {
        void Greet(string name);
    }

    public class GreetingService : IGreetingService
    {
        public void Greet(string name)
        {
            Console.WriteLine($"Привіт, {name}!");
        }
    }

    public class App
    {
        private readonly IGreetingService _greetingService;
        public App(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public void Run()
        {
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            _greetingService.Greet(name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGreetingService, GreetingService>();
                    services.AddTransient<App>();
                })
                .Build();

            var app = host.Services.GetRequiredService<App>();

            app.Run();
        }
    }
}