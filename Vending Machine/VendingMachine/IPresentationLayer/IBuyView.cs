using iQuest.VendingMachine.Payment;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    public interface IBuyView
    {
        public int RequestProduct();

        public int CheckInput(string userInput);

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
