namespace iQuest.VendingMachine.PresentationLayer
{
    public interface ICashPaymentTerminal
    {
        double AskForMoney();

        void GiveBackChange(double change);
    }
}
