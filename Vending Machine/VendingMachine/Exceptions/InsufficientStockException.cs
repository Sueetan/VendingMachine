using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        private const string DefaultMessage = "Insufficient stock to buy the product";

        public InsufficientStockException()
            : base(DefaultMessage)
        {
        }
    }
}
