using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine.Payment
{
    internal class CashPayment : IPaymentAlgorithm
    {
        private readonly ICashPaymentTerminal cashPayment;

        public string Name => "Cash Payment";

        public CashPayment(ICashPaymentTerminal cashPayment)
        {
            this.cashPayment = cashPayment;
        }

        public void Run(double price)
        {
            double moneyPayed = cashPayment.AskForMoney();

            if (moneyPayed < price)
                throw new PaymentCanceledException();

            var change = moneyPayed - price;

            var roundedChange = Math.Round(change, 2);

            cashPayment.GiveBackChange(roundedChange);
        }
    }
}
