using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHelpers.Tests
{
    [TestClass]
    public class PropertyChangeTrackerTests_CallerMemberName
    {
        [TestMethod]
        public void Tracker_CallerMemberNamePropertyChanged_ReturnsTrue()
        {
            var changer = new FakeClassNameOf("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.LastName = "Jones";
            var result = tracker.WaitForChange("LastName", 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Tracker_CallerMemberNamePropertyNotChanged_ReturnsFalse()
        {
            var changer = new FakeClassNameOf("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            var result = tracker.WaitForChange("LastName", 1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Tracker_CallerMemberNameAllPropertiesChanged_ReturnsTrue()
        {
            var changer = new FakeClassNameOf("John", "Smith");
            var tracker = new PropertyChangeTracker(changer);

            changer.NotifyAllProperties();
            var result = tracker.WaitForChange("LastName", 1);

            Assert.IsTrue(result);
        }
    }
}
