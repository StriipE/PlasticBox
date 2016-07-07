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
        public CommandeGenerator commandeGen;
        public QueryBuilder builderAdministration;

        [TestInitialize]
        public void TestInitialize()
        {
            parameters = new UserParameters(10, 100, DateTime.Now ,10);
            clientGen = new ClientGenerator();
            commandeGen = new CommandeGenerator();
            builderAdministration = new QueryBuilder("administration");
        }
        [TestMethod]
        public void TestGenClient()
        {
            //clientGen.GenerateNewClients(100); // Genère 100 clients
            commandeGen.GenerateNewOrder(100, 12);
                //builderAdministration.

        }

    }
}
