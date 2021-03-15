using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.IPresentationLayer;

namespace iQuest.VendingMachine.Payment
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private readonly ICardPaymentTerminal cardPayment;

        public string Name => "Cash Payment";

        public CardPayment(ICardPaymentTerminal cardPayment)
        {
            this.cardPayment = cardPayment;
        }

        public void Run(double price)
        {
            string cardNumber = cardPayment.AskForCardNumber();

            if (!(cardNumber.Length == 16))
                throw new PaymentCanceledException();
        }
    }
}
