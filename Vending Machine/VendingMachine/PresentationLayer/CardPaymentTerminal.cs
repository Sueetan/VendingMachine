using iQuest.VendingMachine.IPresentationLayer;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CardPaymentTerminal : ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            Console.WriteLine("Please provide a valid card: ");
            string userInput = Console.ReadLine();

            return userInput;
        }
    }
}
