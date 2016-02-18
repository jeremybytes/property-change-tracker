using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestHelpers.Tests
{
    public class FakeClassCallerMemberName : INotifyPropertyChanged
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        public void NotifyAllProperties()
        {
            RaisePropertyChanged(null);
        }

        public FakeClassCallerMemberName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            LastUpdateTime = DateTime.Now;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
