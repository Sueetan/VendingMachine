using System;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class DispenserView : IDispenserView
    {
        public void DispenseProduct(string productName)
        {
            Console.WriteLine($"Get your product : {productName}");
        }
    }
}
