using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestHelpers.Tests
{
    [TestClass]
    public class PropertyChangeTrackerTests
    {
        [TestMethod]
        public void Tracker_SinglePropertyChanged_ReturnsTrue()
        {
            var changer = new FakePropertiesClass("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.LastName = "Jones";
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Tracker_SinglePropertyNotChanged_ReturnsFalse()
        {
            var changer = new FakePropertiesClass("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_MaxWaitExpired_ReturnsFalse()
        {
            var changer = new FakePropertiesClass("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);
            var maxWait = new TimeSpan(0, 0, 0, 0, 60);

            var result = tracker.WaitForChange("LastName", maxWait);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_AllPropertiesChanged_ReturnsTrue()
        {
            var changer = new FakePropertiesClass("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.NotifyAllProperties();
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }


        // Async Tests

        private async void UpdateProperty(int delay, FakePropertiesClass fake)
        {
            await Task.Delay(delay);
            fake.LastName = "Jones";
        }

        [TestMethod]
        public void Tracker_SinglePropertyAsyncCompleted_ReturnsTrue()
        {
            var changer = new FakePropertiesClass("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            UpdateProperty(50, changer);
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Tracker_SinglePropertyAsyncNotCompleted_ReturnsFalse()
        {
            var changer = new FakePropertiesClass("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            UpdateProperty(50, changer);
            var result = tracker.WaitForChange("LastName", 20);

            Assert.IsFalse(result);
        }

    }
}
