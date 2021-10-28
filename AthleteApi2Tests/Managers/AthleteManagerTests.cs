using Microsoft.VisualStudio.TestTools.UnitTesting;
using AthleteApi2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AthleteLibrary;

namespace AthleteApi2.Controllers.Tests
{
    [TestClass()]
    public class AthleteManagerTests
    {
        private AthleteManager _manager = new AthleteManager();
        [TestMethod()]
        public void GetAllAthletesTest()
        {
            Assert.AreEqual(5, _manager.GetAllAthletes().Count());
        }

        [TestMethod()]
        public void AddTest()
        {
            Athlete newAthlete = new Athlete(6, "emily", "Denmark", 190);
            Assert.AreEqual(newAthlete, _manager.Add(newAthlete));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Athlete athlete = new Athlete(6, "hehe", "Norway", 170);
            _manager.Delete(athlete.Id);
            Assert.AreEqual(5, _manager.GetAllAthletes().Count());
            if (athlete == null)
            {
                Assert.Fail();
            }
        }
    }
}