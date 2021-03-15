using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Model;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.Repository
{
    class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>();

        public ProductRepository()
        {
            Product cola = new Product(1, "cola", 2.4, 1);
            Product lays = new Product(2, "lays", 4.3, 7);
            Product lion = new Product(3, "lion", 1.42, 5);
            Product mars = new Product(4, "mars", 1.5, 9);

            products.Add(cola);
            products.Add(lays);
            products.Add(lion);
            products.Add(mars);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetProductByID(int productID)
        {

            foreach (Product product in products)
            {
                if (product.ProductID == productID)
                {
                    return VerifyQuantity(product);
                }
            }
            throw new CancelException();
        }

        public Product VerifyQuantity(Product product)
        {
            if (product.Quantity == 0)
            {
                throw new InsufficientStockException();
            }

            return product;
        }

        public void DecrementStock(int productID)
        {
            foreach (var product in from Product product in products
                                    where product.ProductID == productID
                                    select product)
            {
                product.Quantity--;
            }
        }
    }
}
