using System;
using System.Windows.Input;

namespace ConverterDetachProblem
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<bool> _predicate;

        public DelegateCommand(Action<T> action, Func<bool> predicate)
        {
            _action = action;
            _predicate = predicate;
        }

        private void Execute(T parameter)
        {
            if (_action != null)
            {
                _action(parameter);
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_predicate != null)
            {
                return _predicate();
            }

            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action((T)parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}