namespace Lecture08.Models.ChainOfResponsibility.Approval
{
    public class Purchase
    {
        public int Number { get; set; }

        public double Amount { get; set; }

        public string Purpose { get; set; }

        public Purchase(int number, double amount, string purpose)
        {
            Number = number;
            Amount = amount;
            Purpose = purpose;
        }
    }
}
