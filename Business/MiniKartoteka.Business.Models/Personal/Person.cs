using Prism.Mvvm;
using System.ComponentModel;
using System;

namespace MiniKartoteka.Business.Models.Personal
{
    public class Person : BindableBase, IDataErrorInfo
    {
        #region Properties
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        private DateTime _lastUpdated;
        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set { SetProperty(ref _lastUpdated, value); }
        }
        #endregion Properties

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch(columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrEmpty(_firstName))
                        {
                            error = "First name required";
                        }
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrEmpty(_lastName))
                        {
                            error = "Last name required";
                        }
                        break;
                    case nameof(Age):
                        if (_age < 0 || _age > 140)
                        {
                            error = "Age not in range";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }
        #endregion IDataErrorInfo
    }
}
