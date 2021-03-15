using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly ShelfView shelfView;
        private readonly ProductRepository productRepository;

        public string Name => "look";

        public string Description => "Look at the products";

        public bool CanExecute => true;

        public LookUseCase(ShelfView newShelfView, ProductRepository newProductRepository)
        {
            shelfView = newShelfView;
            productRepository = newProductRepository;
        }

        public void Execute()
        {
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}
