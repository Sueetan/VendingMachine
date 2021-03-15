using iQuest.VendingMachine.Exceptions;
using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CashPaymentTerminal : ICashPaymentTerminal
    {
        public double AskForMoney()
        {
            Console.WriteLine("Enter money to buy the product: ");
            string userInput = Console.ReadLine();

            double money = CheckInput(userInput);

            return money;
        }

        public double CheckInput(string userInput)
        {
            bool isFloat = double.TryParse(userInput, out var money);

            if (!isFloat)
            {
                throw new PaymentCanceledException();
            }

            return money;
        }

        public void GiveBackChange(double change)
        {
            Console.WriteLine($"Here is your change : {change}");
        }
    }
}
