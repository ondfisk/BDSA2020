using System;

namespace Lecture08.Models.ChainOfResponsibility.Approval
{
    public class ChainOfResponsibility
    {
        public static void Run()
        {
            // Setup Chain of Responsibility
            Approver larry = new Manager();
            Approver sam = new VicePresident();
            Approver tammy = new CFO();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            // Wait for user
            Console.ReadKey();
        }
    }
}
