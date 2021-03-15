using iQuest.VendingMachine.Model;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class ShelfView : DisplayBase
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                DisplayLine($"ProductID:{product.ProductID} Name: {product.Name} Price: {product.Price} Quantity: {product.Quantity}", ConsoleColor.Blue);
            }
        }
    }
}
