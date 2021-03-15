using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.PresentationLayer;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainView mainView;

        public VendingMachineApplication(List<IUseCase> useCases, MainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IUseCase> availableUseCases = GetExecutableUseCases();

                IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                try
                {
                    useCase.Execute();
                }
                catch (CancelException exception)
                {
                    DisplayError(exception.Message);
                }
                catch (InsufficientStockException exception)
                {
                    DisplayError(exception.Message);
                }
                catch (InvalidProductException exception)
                {
                    DisplayError(exception.Message);
                }
                catch (PaymentCanceledException exception)
                {
                    DisplayError(exception.Message);
                }

            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }

        public void DisplayError(string exception)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception);
            Console.ForegroundColor = oldColor;
        }
    }
}