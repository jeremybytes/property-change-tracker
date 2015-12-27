using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHelpers.Tests
{
    [TestClass]
    public class PropertyChangeTrackerTests_StandardProperties
    {
        [TestMethod]
        public void Tracker_StandardPropertyChanged_ReturnsTrue()
        {
            var changer = new FakeClassStandardProperties("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.LastName = "Jones";
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Tracker_StandardPropertyNotChanged_ReturnsFalse()
        {
            var changer = new FakeClassStandardProperties("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_StandardAllPropertiesChanged_ReturnsTrue()
        {
            var changer = new FakeClassStandardProperties("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.NotifyAllProperties();
            var result = tracker.WaitForChange("LastName", 100);

            Assert.IsTrue(result);
        }
    }
}
