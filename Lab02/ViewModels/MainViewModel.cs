
using Lab02.Navigation;
using Lab02.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isEnabled = true;
        private readonly NavigationViewModel _navigationViewModel;

        public ViewModelBase CurrentViewModel => _navigationViewModel.CurrentViewModel;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(NavigationViewModel navigation)
        {
            _navigationViewModel = navigation;
            _navigationViewModel.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}