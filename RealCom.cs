using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ABdula
{
    class RealCom : ICommand
    {
        private Func<object, bool> _CanExecute;
        private Action<object> _Execute;


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecute != null)
                return _CanExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        public RealCom(Action<object> execute, Func<object, bool> canExecute)
        {
            _CanExecute = canExecute;
            _Execute = execute;
        }
        public RealCom(Action<object> execute) : this(execute, null) { }
    }
}
