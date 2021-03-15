using iQuest.VendingMachine.Payment;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Payment
{
    public class PaymentUseCase : IPaymentUseCase
    {
        private readonly List<IPaymentAlgorithm> paymentAlgorithms = new List<IPaymentAlgorithm>();

        public PaymentUseCase(IPaymentAlgorithm cashPayment, IPaymentAlgorithm cardPayment)
        {
            paymentAlgorithms.Add(cashPayment);
            paymentAlgorithms.Add(cardPayment);
        }

        public void Execute(double price, int id)
        {
            paymentAlgorithms[id].Run(price);
        }
    }
}
