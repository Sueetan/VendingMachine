namespace iQuest.VendingMachine.Payment
{
    public interface IPaymentAlgorithm
    {
        string Name { get; }

        void Run(double price);
    }
}
