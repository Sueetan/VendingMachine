using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Payment;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestProduct()
        {
            Console.Write("Provide the code for the product you want to buy : ");
            string userInput = Console.ReadLine();

            int productID = CheckInput(userInput);

            return productID;
        }

        public int CheckInput(string userInput)
        {
            bool isInteger = int.TryParse(userInput, out var productID);

            if (!isInteger)
            {
                throw new InvalidProductException();
            }

            return productID;
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {
            Console.WriteLine("Provide the payment method: \n");

            foreach (PaymentMethod method in paymentMethods)
            {
                Console.WriteLine($"{method.Id} for {method.Name} \n");
            }

            string userInput = Console.ReadLine();

            int id = CheckInput(userInput);

            foreach (PaymentMethod method in paymentMethods)
            {
                if (method.Id == id)
                    return id;
            }

            throw new PaymentCanceledException();
        }
    }
}