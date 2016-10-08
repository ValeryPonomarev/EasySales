using System;
using EasySales.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasySales.Infrastructure.RepositoryFramework;
using EasySales.Model.Repositories;

namespace EasySales.UnitTests
{
    [TestClass]
    public class RepositoryFactoryTest
    {
        private TestContext testContext;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }


        [TestMethod]
        public void GetRepositoryTest()
        {
            ICustomerRepository repository = EFRepositoryFactory.GetRepository<ICustomerRepository, Customer>();
            Assert.AreNotEqual(null, repository);
            Assert.AreEqual("CustomerRepository", repository.GetType().Name);
            testContext.WriteLine("Created an ICustomerRepository of type {0}", repository.GetType().Name);
        }
    }
}
