using Lab02.Models;
using Lab02.Navigation;
using Lab02.Services;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Lab02.Commands
{
    public class NavigateToDataCommand : CommandBase
    {
        private readonly NavigationViewModel _navigationViewModel;
        private Person _person = new Person("", "", "", new DateModel());
        private Func<bool> _canExecuteEvaluator;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        
        public override bool CanExecute(object parameter)
        {
            if (_canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = _canExecuteEvaluator.Invoke();
                return result;
            }
        }

        internal NavigateToDataCommand(NavigationViewModel navigationViewModel, Person person, Func<bool> canExecuteEvaluator)
        {
            _navigationViewModel = navigationViewModel;
            _person = person;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        public override void Execute(object parameter)
        {
            _navigationViewModel.CurrentViewModel = new DataOutputViewModel(_navigationViewModel, _person);
        }
    }
}