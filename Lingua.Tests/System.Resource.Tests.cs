using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Resources;
using System.IO;
using System.Threading;
using Lingua.Tests.Helpers;

namespace Lingua.Tests
{


  
    /// <summary>
    /// Me learning a little bit about System.Resource namespace
    /// </summary>
    [TestClass]
    public class SystemResourceTests
    {
    
        public SystemResourceTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion



        [TestMethod]
        public void SystemResourceTests_Should_CreateResxFile()
        {


            var filename = Path.Combine(TestContext.TestRunDirectory, Guid.NewGuid().ToString() + ".resx");


            using (ResourceWriter w = new ResourceWriter(filename))
            {
                w.Generate();
            }

            Assert.IsTrue(File.Exists(filename));
            
        }

        [TestMethod]
        public void SystemResourceTests_Should_WriteUpdateValueToResx()
        {


            var filename = Path.Combine(TestContext.TestRunDirectory, Guid.NewGuid().ToString() + ".resx");

            var inputData = "TheInputData";

            using (ResourceWriter w = new ResourceWriter(filename))
            {

                w.AddResource("InvariantName", inputData);
                w.Generate();
            }

            inputData = "TheUpdatedInputData";

            using (ResourceWriter w = new ResourceWriter(filename))
            {

                w.AddResource("InvariantName", inputData);
                w.Generate();
            }

            var data = string.Empty;

            using( var r = new ResourceReader(filename))
            {
                var rr = r.GetEnumerator();
                rr.MoveNext();

                data = rr.Value as string;

                
            }


            Assert.IsTrue(inputData == data);

        }


        [TestMethod]
        public void SystemResourceTests_Should_WriteValueToResx()
        {


            var filename = Path.Combine(TestContext.TestRunDirectory, Guid.NewGuid().ToString() + ".resx");

            using (ResourceWriter w = new ResourceWriter(filename))
            {

                w.AddResource("InvariantName", "InvariantValue");
                w.Generate();
            }


            var data = string.Empty;

            using (var r = new ResourceReader(filename))
            {
                var rr = r.GetEnumerator();
                rr.MoveNext();

                data = rr.Value as string;


            }


            Assert.IsTrue("InvariantValue" == data);

        }

    }
}
