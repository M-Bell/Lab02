using Lab02.Commands;
using Lab02.Models;
using Lab02.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab02.ViewModels
{
    class DataOutputViewModel : ViewModelBase
    {
        #region fields
        private Person _person;
        #endregion
        public ICommand GotoHome { get; }

        public DataOutputViewModel(NavigationViewModel navigation, Person person)
        {
            GotoHome = new NavigateHomeCommand(navigation);
            _person = person;
        }
        #region properties

        private Person Person
        {
            get { return _person; }
            set { _person = value; }
        }
        public string Greeting
        {
            get
            {
                if (_person.Birthday.Date.Day == DateTime.Now.Day
                    && _person.Birthday.Date.Month == DateTime.Now.Month)
                    return "Congratulations!!! All Silpo discounts are for you today";
                return "Just an ordinary day for unordinary you";
            }
        }

        public string Name
        {
            get { return _person.Name; }
        }

        public string Surname
        {
            get { return _person.Surname; }
        }

        public string Email
        {
            get { return _person.Email; }
        }

        public string Birthday
        {
            get { return _person.Birthday.Date.ToString("dd/MM/yyyy"); }
        }

        private int Age
        {
            get
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(_person.Birthday.Date.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                return age;
            }
        }
        public string SunSign
        {
            get
            {
                return _person.Birthday.GetWesternZodiacSign();
            }
        }

        public string ChineseSign
        {
            get
            {
                return _person.Birthday.GetChineseZodiacSign();
            }
        }

        public bool IsAdult
        {
            get { return Age >= 18; }
        }

        public bool IsBirthday
        {
            get { return DateTime.Now.Equals(_person.Birthday); }
        }
        #endregion
    }
}
