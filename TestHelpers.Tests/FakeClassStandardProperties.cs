using System;
using System.ComponentModel;

namespace TestHelpers.Tests
{
    public class FakeClassStandardProperties : INotifyPropertyChanged
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName == value)
                    return;
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName == value)
                    return;
                lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private DateTime lastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return lastUpdateTime; }
            set
            {
                if (lastUpdateTime == value)
                    return;
                lastUpdateTime = value;
                RaisePropertyChanged("LastUpdateTime");
            }
        }

        public void NotifyAllProperties()
        {
            RaisePropertyChanged();
        }

        public FakeClassStandardProperties(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            LastUpdateTime = DateTime.Now;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
