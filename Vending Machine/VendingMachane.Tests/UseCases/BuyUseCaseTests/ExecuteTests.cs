using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IProductRepository> productRepository;
        private Mock<IAuthenticationService> authenticationService;
        private Mock<IBuyView> buyView;
        private Mock<IDispenserView> dispenserView;
        private BuyUseCase buyUseCase;
        private Mock<IPaymentUseCase> paymentUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            productRepository = new Mock<IProductRepository>();

            authenticationService = new Mock<IAuthenticationService>();

            buyView = new Mock<IBuyView>();
            dispenserView = new Mock<IDispenserView>();

            paymentUseCase = new Mock<IPaymentUseCase>();

            buyUseCase = new BuyUseCase(productRepository.Object, authenticationService.Object, buyView.Object, dispenserView.Object, paymentUseCase.Object);

            buyView
                .Setup(x => x.RequestProduct())
                .Returns(1);

            productRepository
                .Setup(x => x.GetProductByID(1))
                .Returns(new Product(1, "cola", 1.1, 1));

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            buyView
                .Setup(x => x.AskForPaymentMethod(paymentMethods))
                .Returns(1);

            paymentUseCase
                .Setup(x => x.Execute(1.1f, 1));

            productRepository
                .Setup(x => x.DecrementStock(1));

            dispenserView
                .Setup(x => x.DispenseProduct("cola"));
        }

        [TestMethod]
        public void HappyFlow_IdIsRequested()
        {
            buyUseCase.Execute();

            buyView.Verify(x => x.RequestProduct());
        }

        [TestMethod]
        public void HappyFlow_ProductIsRequested()
        {
            buyUseCase.Execute();

            productRepository.Verify(x => x.GetProductByID(1));
        }

        [TestMethod]
        public void HappyFlow_ProductQuantityIsDecremented()
        {
            buyUseCase.Execute();

            productRepository.Verify(x => x.DecrementStock(1));
        }

        [TestMethod]
        public void HappyFlow_ProductIsDisplayed()
        {
            buyUseCase.Execute();

            dispenserView.Verify(x => x.DispenseProduct("cola"));
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThrowInvalidProductException()
        {
            buyView.Setup(x => x.RequestProduct())
                .Throws(new InvalidProductException());

            Assert.ThrowsException<InvalidProductException>(() =>
            {
                buyUseCase.Execute();
            });
        }
    }
}
