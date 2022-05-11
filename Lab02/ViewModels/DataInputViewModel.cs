using Lab02.Commands;
using Lab02.Models;
using Lab02.Navigation;
using System;
using System.Windows;
using System.Windows.Input;

namespace Lab02.ViewModels
{
    public class DataInputViewModel : ViewModelBase
    {
        private Person _person;
        private string _name = "";
        private string _surname = "";
        private string _email = "example@mail.com";
        private DateModel _birthday = new();
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
            _person = new Person(_name, _surname, _email, _birthday);
            _gotoData = new NavigateToDataCommand(navigation, _person, IsValid, this);
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public DateTime Date
        {
            get { return _birthday.Date; }
            set { _birthday.Date = value; }
        }

        private bool IsValid()
        {
            InterfaceIsEnabled = false;
            try
            {
                _person.Name = _name;
                _person.Surname = _surname;
                _person.Birthday = _birthday;
                _person.Email = _email;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                InterfaceIsEnabled = true;
            }
            return true;
        }
    }
}
