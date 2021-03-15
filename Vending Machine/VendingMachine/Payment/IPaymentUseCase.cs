namespace iQuest.VendingMachine.Payment
{
    public interface IPaymentUseCase
    {
        void Execute(double price, int id);
    }
}
