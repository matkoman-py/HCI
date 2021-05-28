using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Func<Boolean> _validator;
        private Action _execution;

        public DelegateCommand(Action execution)
        {
            _execution = execution;
            _validator = () => true;
        }

        public DelegateCommand(Func<Boolean> validator, Action execution) {
            _validator = validator;
            _execution = execution;
        }
        public bool CanExecute(object parameter)
        {
            return _validator();
        }

        public void Execute(object parameter)
        {
            _execution();
        }
    }
}
