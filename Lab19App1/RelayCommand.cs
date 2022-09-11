using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19App1
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canexecute;
        public event EventHandler CanExecuteChanged
        {
               add=>CommandManager.RequerySuggested += value; 
               remove=>CommandManager.RequerySuggested -= value;
        }
        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute=null)
        {
            execute = Execute ??  throw new ArgumentException(nameof(Execute));
            canexecute = CanExecute;
        }

        public bool CanExecute(object parameter)=> canexecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)=> execute(parameter);
    }
}
