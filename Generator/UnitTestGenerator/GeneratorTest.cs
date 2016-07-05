using System;
using Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGenerator
{
    [TestClass]
    public class GeneratorTest
    {
        public UserParameters parameters;
        [TestInitialize]
        public void TestInitialize()
        {
            parameters = new UserParameters(10, 100, DateTime.Now ,10);
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(10, parameters.SalesVariationPercentage);
        }
        [TestMethod]
        public void TestGenClient()
        {
            Assert.AreEqual("alexandre.aubert@gmail.com", Client.GenerateNewClient());
        }

    }
}
