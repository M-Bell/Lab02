using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            set { _email = value; }
        }

        public DateModel Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
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
            Email = "";
            Birthday = new DateModel();
        }

        #endregion

    }
}
