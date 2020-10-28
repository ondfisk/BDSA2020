// Taken from: https://www.journaldev.com/1617/chain-of-responsibility-design-pattern-in-java#chain-of-responsibility-design-pattern-example

namespace Lecture08.Models.ChainOfResponsibility.ATM
{
    public interface IDispenseChain
    {
        IDispenseChain Next { set; }

        void Dispense(Currency currency);
    }
}