using System;

namespace Lecture08.Models.ChainOfResponsibility.Approval
{
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine($"{nameof(VicePresident)} approved request no. {purchase.Number}");
            }
            else if (_successor != null)
            {
                _successor.ProcessRequest(purchase);
            }
        }
    }
}
