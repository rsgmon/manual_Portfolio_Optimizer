﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModelOptimizer111314.Model
{
    class RelayCommand : ICommand
    {
        readonly Action<object> _execute; 
        readonly Predicate<object> _canExecute;  

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Predicate<object> canExectue)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExectue;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
