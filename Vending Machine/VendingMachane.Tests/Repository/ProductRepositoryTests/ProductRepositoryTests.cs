using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace VendingMachine.Tests.Repository.ProductRepositoryTests
{
    [TestClass]
    public class ProductRepositoryTests
    {
        private ProductRepository productRepository;

        [TestInitialize]
        public void TestSetup()
        {
            productRepository = new ProductRepository();
        }

        [TestMethod]
        public void GetAllProduct_Always_ReturnsProducts()
        {
            List<Product> products = new List<Product>();

            Assert.IsTrue(productRepository.GetAll().GetType() == products.GetType());
        }

        [TestMethod]
        public void GetProductByID_HavingAValidID_ReturnsAProduct()
        {
            Product product = productRepository.GetProductByID(1);

            Assert.IsTrue(product.ProductID == 1);
        }

        [TestMethod]
        public void GetProductByID_HavingInvalidID_ThrowsCancelException()
        {
            Assert.ThrowsException<CancelException>(() =>
            {
                productRepository.GetProductByID(10);
            });

        }

        [TestMethod]
        public void VerifyQuantity_HavingValidQuantity_ReturnsProduct()
        {
            Product givenProduct = new Product(1, "cola", 1.1f, 1);

            Product product = productRepository.VerifyQuantity(givenProduct);

            Assert.AreEqual(givenProduct, product);
        }

        [TestMethod]
        public void VerifyQuantity_HavingInValidQuantity_ThrowsInsufficientStockException()
        {
            Product product = new Product(1, "cola", 1.1f, 0);

            Assert.ThrowsException<InsufficientStockException>(() =>
            {
                productRepository.VerifyQuantity(product);
            });
        }

        [TestMethod]
        public void DecrementStock_DecrementQuantityOfProduct()
        {
            Product product = productRepository.GetProductByID(1);

            productRepository.DecrementStock(product.ProductID);

            Assert.AreEqual(0, product.Quantity);
        }
    }
}
