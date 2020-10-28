using System;

namespace Lecture08.Models.ChainOfResponsibility.Approval
{
    public class CFO : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine($"{nameof(CFO)} approved request no. {purchase.Number}");
            }
            else
            {
                Console.WriteLine($"Request no. {purchase.Number} requires an executive meeting!");
            }
        }
    }
}
