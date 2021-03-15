using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.UseCases;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            MainView mainView = new MainView();
            LoginView loginView = new LoginView();
            ShelfView shelfView = new ShelfView();
            BuyView buyView = new BuyView();
            DispenserView dispenserView = new DispenserView();
            CardPaymentTerminal cardPaymentTerminal = new CardPaymentTerminal();
            CashPaymentTerminal cashPaymentTerminal = new CashPaymentTerminal();

            AuthenticationService authenticationService = new AuthenticationService();

            ProductRepository productRepository = new ProductRepository();

            CashPayment cashPayment = new CashPayment(cashPaymentTerminal);
            CardPayment cardPayment = new CardPayment(cardPaymentTerminal);

            PaymentUseCase paymentUseCase = new PaymentUseCase(cashPayment, cardPayment);

            List<IUseCase> useCases = new List<IUseCase>
            {
                new LoginUseCase(authenticationService, loginView),
                new LogoutUseCase(authenticationService),
                new LookUseCase(shelfView,productRepository),
                new BuyUseCase(productRepository,authenticationService,buyView,dispenserView,paymentUseCase),
            };

            return new VendingMachineApplication(useCases, mainView);
        }
    }
}