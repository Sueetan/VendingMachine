using System;

namespace iQuest.VendingMachine.Exceptions
{
    internal class CancelException : Exception
    {
        private const string DefaultMessage = "You canceled the operation";

        public CancelException()
            : base(DefaultMessage)
        {
        }
    }
}
