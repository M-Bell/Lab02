using Lab02.Models;
using Lab02.Navigation;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab02.Commands
{
    public class NavigateToDataCommand : CommandBase
    {
        private readonly NavigationViewModel _navigationViewModel;
        private readonly DataInputViewModel _dataInputViewModel;
        private Person _person = new Person();
        private Func<bool> _canExecuteEvaluator;

        new public event EventHandler CanExecuteChanged
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

        internal NavigateToDataCommand(NavigationViewModel navigationViewModel, Person person, Func<bool> canExecuteEvaluator, DataInputViewModel dataInputViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _person = person;
            _canExecuteEvaluator = canExecuteEvaluator;
            _dataInputViewModel = dataInputViewModel;
        }

        public override async void Execute(object parameter)
        {
            _dataInputViewModel.InterfaceIsEnabled = false;
            _navigationViewModel.CurrentViewModel = await Task.Run(() => new DataOutputViewModel(_navigationViewModel, _person));


        }
    }
}