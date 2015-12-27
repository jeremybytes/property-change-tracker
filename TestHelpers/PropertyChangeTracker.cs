using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestHelpers
{
    public class PropertyChangeTracker
    {
        private List<string> notifications = new List<string>();

        public PropertyChangeTracker(INotifyPropertyChanged changer)
        {
            changer.PropertyChanged += (o, e) =>
                {
                    if (string.IsNullOrEmpty(e.PropertyName))
                        notifications.Add("**ALL**");
                    else
                        notifications.Add(e.PropertyName);
                };
        }

        public string[] ChangedProperties
        {
            get { return notifications.ToArray(); }
        }

        public bool WaitForChange(string propertyName, int maxWaitMilliseconds)
        {
            var startTime = DateTime.UtcNow;
            while (!notifications.Contains(propertyName) &&
                   !notifications.Contains("**ALL**"))
            {
                if (startTime.AddMilliseconds(maxWaitMilliseconds) < DateTime.UtcNow)
                    return false;
            }
            return true;
        }

        public void Reset()
        {
            notifications.Clear();
        }
    }
}
