using Lab02.Navigation;
using Lab02.Services;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Commands
{
    public class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationViewModel _navigationViewModel;

        public NavigateHomeCommand(NavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationViewModel.CurrentViewModel = new DataInputViewModel(_navigationViewModel);
        }
    }
}