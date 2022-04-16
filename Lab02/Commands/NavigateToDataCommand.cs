using Lab02.Models;
using Lab02.Navigation;
using Lab02.Services;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Commands
{
    public class NavigateToDataCommand : CommandBase
    {
        private readonly NavigationViewModel _navigationViewModel;
        private Person _person = new Person("", "", "", new DateModel());

        internal NavigateToDataCommand(NavigationViewModel navigationViewModel, Person person)
        {
            _navigationViewModel = navigationViewModel;
            _person = person;

        }

        public override void Execute(object parameter)
        {
            _navigationViewModel.CurrentViewModel = new DataOutputViewModel(_navigationViewModel, _person);
        }
    }
}