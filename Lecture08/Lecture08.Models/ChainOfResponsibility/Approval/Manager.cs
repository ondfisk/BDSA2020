using System;

namespace Lecture08.Models.ChainOfResponsibility.Approval
{
    public class Manager : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine($"{nameof(Manager)} approved request no. {purchase.Number}");
            }
            else if (_successor != null)
            {
                _successor.ProcessRequest(purchase);
            }
        }
    }
}
