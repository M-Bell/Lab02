
using Lab02.Commands;
using Lab02.Models;
using Lab02.Navigation;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab02.ViewModels
{
    public class DataInputViewModel : ViewModelBase
    {
        private Person _person = new();
        private bool _interfaceIsEnabled = true;
        private ICommand _gotoData;

        public ICommand GotoData
        {
            get
            {
                return _gotoData;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Name) &&
                    !String.IsNullOrWhiteSpace(Surname) &&
                    !String.IsNullOrWhiteSpace(Email);
            }
        }

        public bool InterfaceIsEnabled
        {
            get
            {
                return _interfaceIsEnabled;
            }
            set
            {
                _interfaceIsEnabled = value;
                OnPropertyChanged();
            }
        }


        public DataInputViewModel(NavigationViewModel navigation)
        {
            _gotoData = new NavigateToDataCommand(navigation, _person, IsValid, this);
        }

        public string Name
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public string Surname
        {
            get { return _person.Surname; }
            set
            {
                _person.Surname = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public string Email
        {
            get { return _person.Email; }
            set
            {
                _person.Email = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public DateTime Date
        {
            get { return _person.Birthday.Date; }
            set { _person.Birthday.Date = value; }
        }

        private bool IsValid()
        {
            if (_person.Birthday == null) return false;
            DateTime lowerLimit = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day);
            if (_person.Birthday.Date.CompareTo(lowerLimit) < 0)
            {
                MessageBox.Show($"ERROR\nAren't you too old for this...?");
                return false;
            }
            else if (DateTime.Now.CompareTo(_person.Birthday.Date) < 0)
            {
                MessageBox.Show($"ERROR\nYou couldn't even be born");
                return false;
            }

            return true;
        }
    }
}
