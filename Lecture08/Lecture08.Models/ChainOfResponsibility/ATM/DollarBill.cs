// Taken from: https://www.journaldev.com/1617/chain-of-responsibility-design-pattern-in-java#chain-of-responsibility-design-pattern-example

using System;

namespace Lecture08.Models.ChainOfResponsibility.ATM
{
    public class DollarBill : IDispenseChain
    {
        private readonly int _amount;

        public IDispenseChain Next { private get; set; }

        public DollarBill(int amount)
        {
            _amount = amount;
        }

        // Greedy algorithm implemented by chain of responsibility
        public void Dispense(Currency currency)
        {
            if (currency.Amount >= _amount)
            {
                var numberOfBills = currency.Amount / _amount;
                var remainder = currency.Amount % _amount;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Dispensing {numberOfBills} {_amount}$ note(s)");
                Console.ResetColor();

                if (remainder != 0)
                {
                    Next.Dispense(new Currency(remainder));
                }
            }
            else
            {
                Next.Dispense(currency);
            }
        }
    }
}