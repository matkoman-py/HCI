using ReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            viewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            String viewCommand = parameter.ToString();

            switch (viewCommand) 
            {
                case "Profile":
                    viewModel.SelectedViewModel = new ProfileViewModel(this);
                    break;
                case "Login":
                    viewModel.SelectedViewModel = new LoginViewModel(this);
                    break;
                case "UserHomePage":
                    viewModel.SelectedViewModel = new UserHomePageViewModel(this);
                    break;
                case "DataUpdate":
                    viewModel.SelectedViewModel = new DataUpdateViewModel(this);
                    break;
                case "RequestCreation":
                    viewModel.SelectedViewModel = new RequesCreationViewModel(this);
                    break;
                case "ChooseOrganisatorPage":
                    viewModel.SelectedViewModel = new ChooseOrganisatorPageViewModel(this);
                    break;
            }
        }
    }
}
