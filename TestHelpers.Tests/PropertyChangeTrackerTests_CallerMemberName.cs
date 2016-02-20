using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestHelpers.Tests
{
    [TestClass]
    public class PropertyChangeTrackerTests_CallerMemberName
    {
        [TestMethod]
        public void Tracker_CallerMemberNamePropertyChanged_ReturnsTrue()
        {
            var changer = new FakeClassCallerMemberName("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.LastName = "Jones";
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Tracker_CallerMemberNamePropertyNotChanged_ReturnsFalse()
        {
            var changer = new FakeClassCallerMemberName("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_CallerMemberNameMaxWaitExpired_ReturnsFalse()
        {
            var changer = new FakeClassCallerMemberName("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);
            var maxWait = new TimeSpan(0, 0, 0, 0, 60);

            var result = tracker.WaitForChange("LastName", maxWait);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_CallerMemberNameAllPropertiesChanged_ReturnsTrue()
        {
            var changer = new FakeClassCallerMemberName("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.NotifyAllProperties();
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }
    }
}
