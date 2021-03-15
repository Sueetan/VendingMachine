using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class InvalidProductException : Exception
    {
        private const string DefaultMessage = "Product can't be found";

        public InvalidProductException()
            : base(DefaultMessage)
        {
        }
    }
}
