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

        public bool WaitForChange(string propertyName, int maxWaitSeconds)
        {
            var startTime = DateTime.Now;
            while (!notifications.Contains(propertyName) &&
                   !notifications.Contains("**ALL**"))
            {
                var diff = DateTime.Now - startTime;
                if (diff.TotalSeconds > maxWaitSeconds)
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
