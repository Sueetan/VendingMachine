using iQuest.VendingMachine.IPresentationLayer;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VendingMachine.Tests.Payment
{
    [TestClass]
    public class PaymentAlgorithmTests
    {
        private Mock<ICashPaymentTerminal> cashPaymentTerminal;
        private Mock<ICardPaymentTerminal> cardPaymentTerminal;
        private Mock<IPaymentAlgorithm> cashPayment;
        private Mock<IPaymentAlgorithm> cardPayment;

        private PaymentUseCase paymentUseCase;

        [TestInitialize]
        public void TestSetup()
        {
            cashPaymentTerminal = new Mock<ICashPaymentTerminal>();
            cardPaymentTerminal = new Mock<ICardPaymentTerminal>();
            cashPayment = new Mock<IPaymentAlgorithm>();
            cardPayment = new Mock<IPaymentAlgorithm>();

            paymentUseCase = new PaymentUseCase(cashPayment.Object, cardPayment.Object);

        }

        [TestMethod]
        public void HappyFlow_CardNumberIsRequested()
        {
            cardPaymentTerminal
                .Setup(x => x.AskForCardNumber())
                .Returns("123456789123456");

            cardPayment.Setup(x => x.Run(1.1));

            paymentUseCase.Execute(1.1, 1);
        }

        [TestMethod]
        public void HappyFlow_CashAmountIsRequested()
        {
            cashPaymentTerminal
                .Setup(x => x.AskForMoney())
                .Returns(1.1f);

            cashPayment.Setup(x => x.Run(1.1));

            paymentUseCase.Execute(1.1, 0);
        }
    }
}
