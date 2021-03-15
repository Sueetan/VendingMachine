using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class ConstructorTests
    {
        private Mock<IProductRepository> productRepository;
        private Mock<IAuthenticationService> authenticationService;
        private Mock<IBuyView> buyView;
        private Mock<IDispenserView> dispenserView;
        private Mock<IPaymentUseCase> paymentUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            productRepository = new Mock<IProductRepository>();

            authenticationService = new Mock<IAuthenticationService>();

            buyView = new Mock<IBuyView>();
            dispenserView = new Mock<IDispenserView>();

            paymentUseCase = new Mock<IPaymentUseCase>(); ;
        }

        [TestMethod]
        public void HappyFlow_CreatesBuyUseCase()
        {
            Assert.IsNotNull(new BuyUseCase(productRepository.Object, authenticationService.Object, buyView.Object, dispenserView.Object, paymentUseCase.Object));
        }

        [TestMethod]
        public void HavingNullProductRepository_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(null, authenticationService.Object, buyView.Object, dispenserView.Object, paymentUseCase.Object);
            });
        }

        [TestMethod]
        public void HavingNullAuthenticationService_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(productRepository.Object, null, buyView.Object, dispenserView.Object, paymentUseCase.Object);
            });
        }

        [TestMethod]
        public void HavingNullBuyView_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(productRepository.Object, authenticationService.Object, null, dispenserView.Object, paymentUseCase.Object);
            });
        }

        [TestMethod]
        public void HavingNullDispenserView_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(productRepository.Object, authenticationService.Object, buyView.Object, null, paymentUseCase.Object);
            });
        }

        [TestMethod]
        public void Name_Always_IsAsExpected()
        {
            BuyUseCase buyUseCase = new BuyUseCase(productRepository.Object, authenticationService.Object,
                buyView.Object, dispenserView.Object, paymentUseCase.Object);

            Assert.IsTrue(buyUseCase.Name == "buy");
        }

        [TestMethod]
        public void Description_Always_IsAsExpected()
        {
            BuyUseCase buyUseCase = new BuyUseCase(productRepository.Object, authenticationService.Object,
                buyView.Object, dispenserView.Object, paymentUseCase.Object);

            Assert.IsTrue(buyUseCase.Description == "Buy a product");
        }
    }
}
