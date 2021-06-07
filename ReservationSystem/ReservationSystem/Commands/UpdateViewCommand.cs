using ReservationSystem.Models;
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

        private IMainWindow viewModel;

        public UpdateViewCommand(IMainWindow baseViewModel)
        {
            viewModel = baseViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            BaseViewModel dto = (BaseViewModel)parameter;
            viewModel.SelectedViewModel = dto;
        }

    }
}
