using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class PaymentCanceledException : Exception
    {
        private const string DefaultMessage = "You canceled the payment";

        public PaymentCanceledException()
            : base(DefaultMessage)
        { }
    }
}
