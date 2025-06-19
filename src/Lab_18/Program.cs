using System;
using System.Collections.Generic;

namespace Lab_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) IAnimal");
            Console.WriteLine("2) IPaymentMethod");
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
        public interface IAnimal
        {
            void Speak();
            void Eat();
        }

        public class Dog : IAnimal
        {
            public void Speak() => Console.WriteLine("Собака каже - гав");
            public void Eat() => Console.WriteLine("Собака їсть - м'ясо");
        }

        public class Cat : IAnimal
        {
            public void Speak() => Console.WriteLine("Кіт каже - мау");
            public void Eat() => Console.WriteLine("Кіт їсть - рибу");
        }

        public static void Run()
        {

            List<IAnimal> animals = new List<IAnimal>
            {
                new Dog(),
                new Cat(),
                new Dog(),
                new Cat()
            };

            foreach (var animal in animals)
            {
                animal.Speak();
                animal.Eat();
                Console.WriteLine();
            }
        }
    }




    public static class Task2
    {
        public interface IPaymentMethod
        {
            void Pay(decimal amount);
        }

        public class CreditCard : IPaymentMethod
        {
            public void Pay(decimal amount) =>
                Console.WriteLine($"Оплачено {amount} грн. кредитною карткою");

        }

        public class PayPal : IPaymentMethod
        {
            public void Pay(decimal amount) =>
                Console.WriteLine($"Оплачено {amount} грн. через PayPal");

        }

        public class ApplePay : IPaymentMethod
        {
            public void Pay(decimal amount) =>
                Console.WriteLine($"Оплачено {amount} грн. через ApplePay");

        }


        public class Order
        {
            public IPaymentMethod PaymentMethod { get; }

            public Order(IPaymentMethod paymentMethod)
            {
                PaymentMethod = paymentMethod;
            }

            public void ProcessPayment(decimal amount)
            {
                PaymentMethod.Pay(amount);
                Console.WriteLine("Платеж пройшов успішно");
            }
        }

        public static void Run()
        {
            var orders = new List<Order>
            {
                new Order(new CreditCard()),
                new Order(new PayPal()),
                new Order(new ApplePay())
            };

            decimal[] amounts = { 500.50m, 750.25m, 300.75m };

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Замовлення {i + 1}:");
                orders[i].ProcessPayment(amounts[i]);
            }
        }
    }
}