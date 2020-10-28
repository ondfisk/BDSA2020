// Taken from: https://www.journaldev.com/1617/chain-of-responsibility-design-pattern-in-java#chain-of-responsibility-design-pattern-example

using System;

namespace Lecture08.Models.ChainOfResponsibility.ATM
{
    public class ATM
    {
        private readonly IDispenseChain _chain;

        public ATM()
        {
            // initialize the chain
            var c100 = new DollarBill(100);
            var c50 = new DollarBill(50);
            var c20 = new DollarBill(20);
            var c10 = new DollarBill(10);

            c100.Next = c50;
            c50.Next = c20;
            c20.Next = c10;

            _chain = c100;
        }

        public void Dispense(Currency currency)
        {
            _chain.Dispense(currency);
        }

        public static void Run()
        {
            var atm = new ATM();

            while (true)
            {
                Console.WriteLine("Enter amount to dispense (0 to exit)");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out var amount))
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }

                if (amount == 0)
                {
                    break;
                }

                if (amount % 10 != 0)
                {
                    Console.WriteLine("Amount should be in multiple of 10s.");
                    continue;
                }

                atm.Dispense(new Currency(amount));
            }
        }
    }
}