using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var accounts = new Dictionary<string, double>();
            var accountInfo = Console.ReadLine().Split(',');
            foreach (var account in accountInfo)
            {
                var tokens = account.Split('-');
                var accountNum = tokens[0];
                var initialValue = double.Parse(tokens[1]);

                accounts.Add(accountNum, initialValue);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var info = command.Split(' ');
                string action = info[0];
                var accountNum = info[1];
                var value = double.Parse(info[2]);
                try
                {
                    Func<string, double, Dictionary<string, double>, bool> operation = GetType(action);

                    if (operation(accountNum, value, accounts))
                    {
                        Console.WriteLine($"Account {accountNum} has new balance: {accounts[accountNum]:f2}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Enter another command");
            }
        }

        private static Func<string, double, Dictionary<string, double>, bool> GetType(string action)
        {
            switch (action)
            {
                case "Deposit":
                    return Deposit;
                case "Withdraw":
                    return Withdraw;
                default:
                    throw new Exception("Invalid command!");
            }
        }

        private static bool Deposit(string accountNum, double value, Dictionary<string, double> accounts)
        {
            if (!accounts.ContainsKey(accountNum))
            {
                throw new Exception("Invalid account!");
            }

            accounts[accountNum] += value;
            return true;
        }

        private static bool Withdraw(string accountNum, double value, Dictionary<string, double> accounts)
        {
            if (!accounts.ContainsKey(accountNum))
            {
                throw new Exception("Invalid account!");
            }
            if (accounts[accountNum] - value < 0)
            {
                throw new Exception("Insufficient balance!");
            }

            accounts[accountNum] -= value;
            return true;
        }

    }
}
