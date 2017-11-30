using System;
using Pomodoro.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Pomodoro
{
    [TestClass]
    public class TrackerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Tracker tracker = new Tracker();
            tracker.Track(DateTime.Now.AddMinutes(-30), DateTime.Now); 
        }
    }
}
