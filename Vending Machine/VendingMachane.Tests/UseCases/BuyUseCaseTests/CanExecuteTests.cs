using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.UseCases.BuyUseCaseTests
{
    [TestClass]
    public class CanExecuteTests
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
        public void HavingUserLoggedIn_ReturnsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            BuyUseCase buyUseCase = new BuyUseCase(productRepository.Object, authenticationService.Object, buyView.Object, dispenserView.Object, paymentUseCase.Object);

            Assert.IsTrue(buyUseCase.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_ReturnsFalse()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            BuyUseCase buyUseCase = new BuyUseCase(productRepository.Object, authenticationService.Object, buyView.Object, dispenserView.Object, paymentUseCase.Object);

            Assert.IsFalse(buyUseCase.CanExecute);
        }
    }
}
