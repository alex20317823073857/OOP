using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facilities;

namespace FacilitiesUnitTestProject
{
    [TestClass]
    public class FacilitiesUnitTests
    {
        [TestMethod]
        public void ClientTest()
        {
            var client = new Client();

            Assert.AreEqual(34, client.DoCalls());
        }
    }
}
