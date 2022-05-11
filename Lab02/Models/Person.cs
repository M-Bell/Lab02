using Lab02.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab02.Models
{

    class Person
    {
        #region fields
        private string _name;
        private string _surname;
        private string _email;
        private DateModel _birthday;
        private static Regex emailRegex = new Regex(@"^[\w]+@[\w]+\.[\w]+$");
        private static DateTime lowerLimit =
            new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day);

        #endregion

        #region properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (emailRegex.IsMatch(value))
                {
                    _email = value;
                }
                else
                {
                    throw new InvalidEmailException($"ERROR\nInvalid email...");
                }
            }
        }

        public DateModel Birthday
        {
            get { return _birthday; }
            set
            {
                if (value.Date.CompareTo(lowerLimit) < 0)
                {
                    throw new InvalidEmailException($"ERROR\nAren't you too old for this?");
                }
                else if (DateTime.Now.CompareTo(value.Date) < 0)
                {
                    throw new InvalidEmailException($"ERROR\nYou couldn't even be born");
                }
                else
                {
                    _birthday = value;
                }
            }
        }
        #endregion

        #region constructors
        public Person(string name, string surname, string email, DateModel birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = new DateModel();
        }

        public Person(string name, string surname, DateModel birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Person()
        {
            Name = "";
            Surname = "";
            Email = "example@mail.com";
            Birthday = new DateModel();
        }

        #endregion

    }
}
