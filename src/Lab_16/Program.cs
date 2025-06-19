using System;
using System.Threading.Tasks;

namespace Lab_16
{
    namespace BankAcctSim
    {
        public class BankAcc
        {
            private int _balance;
            private readonly object _balanceLock = new object();

            public int Balance
            {
                get
                {
                    lock (_balanceLock)
                    {
                        return _balance;
                    }
                }
            }

            public async Task DepositAsync(int amount)
            {

                lock (_balanceLock)
                {
                    _balance += amount;
                    Console.WriteLine($"Поповнення +{amount}");
                }

            }

            public async Task WithdrawAsync(int amount)
            {
                lock (_balanceLock)
                {

                    if (_balance >= amount)
                    {
                        _balance -= amount;
                        Console.WriteLine($"Зняття -{amount}");
                    }
                    else
                    {
                        Console.WriteLine($"Недостатньо коштів на рахунку: {amount}");
                    }


                }
            }
        }

        class Program
        {
            static async Task Main(string[] args)
            {
                var account = new BankAcc();

                var task1 = account.DepositAsync(200); // +
                var task2 = account.WithdrawAsync(100); // -
                var task3 = account.DepositAsync(300); // +
                var task4 = account.WithdrawAsync(50); // -

                await Task.WhenAll(task1, task2, task3, task4);
                Console.WriteLine($"Фінальний баланс: {account.Balance}");
            }
        }
    }
}
