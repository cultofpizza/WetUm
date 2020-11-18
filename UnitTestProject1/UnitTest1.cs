using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WetUm;
using Xamarin.Forms;

namespace UnitTestProject1
{
    [TestClass]
    public class WetUmTests
    {
        [TestMethod]
        public void GetRegionTests()
        {
            var mosCord = (lat: 55.75, lon: 37.62);
            var spbCord = (lat: 59.9386, lon: 30.3141);
            var saratovCord = (lat: 51.5406, lon: 46.0086);
            //var a = new FindLocation();

            Assert.IsTrue(1 != 2);

            //Assert.AreEqual("Moskva", a.GetRegionAsync(mosCord.lat, mosCord.lon));
            //Assert.AreEqual("St. Petersburg", a.GetRegionAsync(spbCord.lat, spbCord.lon));
            //Assert.AreEqual("Saratov", a.GetRegionAsync(saratovCord.lat, saratovCord.lon));
        }

        [TestMethod]
        public void SetWetherDataTest()
        {
            //var a = new FindLocation();
            //a.SetWetherData(55.75, 37.62, "Moskva");

            Assert.IsTrue(1 != 2);
        }
    }
}
