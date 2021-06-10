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
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Func<Boolean> _validator;
        private Action _execution;
        private Func<Object, Object> _parameter_execution;
        private bool _hasParameter;

        public DelegateCommand(Action execution)
        {
            _execution = execution;
            _validator = () => true;
        }

        public DelegateCommand(Func<Object, Object> execution) 
        {
            _parameter_execution = execution;
            _validator = () => true;
            _hasParameter = true;
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
            if (_hasParameter)
            {
                _parameter_execution(parameter);
            }
            else 
            {
                if (_validator())
                    _execution();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
