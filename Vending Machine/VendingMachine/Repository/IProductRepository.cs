using iQuest.VendingMachine.Model;
using System.Collections.Generic;

namespace iQuest.VendingMachine.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetProductByID(int productID);

        Product VerifyQuantity(Product product);

        void DecrementStock(int productID);
    }
}
