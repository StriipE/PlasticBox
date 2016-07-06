using System;
using Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGenerator
{
    [TestClass]
    public class GeneratorTest
    {
        public UserParameters parameters;
        public ClientGenerator clientGen;
        public QueryBuilder builderAdministration;

        [TestInitialize]
        public void TestInitialize()
        {
            parameters = new UserParameters(10, 100, DateTime.Now ,10);
            clientGen = new ClientGenerator();
            builderAdministration = new QueryBuilder("administration");
        }
        [TestMethod]
        public void TestGenClient()
        {
                clientGen.GenerateNewClients(10000); // Genère 100 clients
                //builderAdministration.

        }

    }
}
