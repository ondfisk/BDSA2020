namespace Lecture08.Models.ChainOfResponsibility.Approval
{
    public abstract class Approver
    {
        protected Approver _successor;

        public void SetSuccessor(Approver successor)
        {
            _successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}
