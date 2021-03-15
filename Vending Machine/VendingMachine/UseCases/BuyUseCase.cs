using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model;
using iQuest.VendingMachine.Payment;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Tests")]

namespace iQuest.VendingMachine.UseCases
{
    public class BuyUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IBuyView buyView;
        private readonly IDispenserView dispenserView;
        private readonly IAuthenticationService authenticationService;
        private readonly IPaymentUseCase paymentUseCase;
        public string Name => "buy";

        public string Description => "Buy a product";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public BuyUseCase(IProductRepository productRepository, IAuthenticationService authenticationService, IBuyView buyView, IDispenserView dispenserView, IPaymentUseCase paymentUseCase)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(productRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(productRepository));
            this.dispenserView = dispenserView ?? throw new ArgumentNullException(nameof(productRepository));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public void Execute()
        {
            int productID = buyView.RequestProduct();

            Product product = productRepository.GetProductByID(productID);

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            PaymentMethod cash = new PaymentMethod(0, "cash");
            PaymentMethod card = new PaymentMethod(1, "card");

            paymentMethods.Add(cash);
            paymentMethods.Add(card);

            int paymentMethod = buyView.AskForPaymentMethod(paymentMethods);

            paymentUseCase.Execute(product.Price, paymentMethod);

            productRepository.DecrementStock(productID);

            dispenserView.DispenseProduct(product.Name);
        }
    }
}
