using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasySales.Model.Customers;
using EasySales.Infrastructure.RepositoryFramework;

namespace EasySales.UnitTests
{
    /// <summary>
    /// Тест на получение, добавление, удаление и изменение записей из Customerrepository
    /// </summary>
    [TestClass]
    public class CustomerrepositoryTest
    {
        private TestContext testContextInstance;
        private ICustomerRepository repository;

        public CustomerrepositoryTest()
        {
            repository = EFRepositoryFactory.GetRepository<ICustomerRepository, Customer>();
        }
        
        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }
        
        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void GetCustomerRepositoryTest()
        {
            Assert.AreNotEqual(null, repository);
            Assert.AreEqual("CustomerRepository", repository.GetType().Name);
            TestContext.WriteLine("Created an ICustomerRepository of type {0}", repository.GetType().Name);
        }

        [TestMethod()]
        public void AddCustomer()
        {
            int countCustomers = repository.FindAll().Count;

            Customer customer = new Customer() { Name = "UnitTestCustomer", Key = Guid.NewGuid() };
            repository.Add(customer);
            repository.Save();

            int currentCountCustomers = repository.FindAll().Count;

            Assert.IsTrue(countCustomers == currentCountCustomers - 1);
        }

        [TestMethod()]
        public void FindAllCustomers()
        {
            IList<Customer> customers = repository.FindAll();
            Assert.IsTrue(customers.Count > 0);
            testContextInstance.WriteLine("В базе надено {0} контрагентов", customers.Count);
        }

        [TestMethod()]
        public void FindByKeyCustomer()
        {
            IList<Customer> customers = repository.FindAll();
            Assert.IsTrue(customers.Count > 0, "Не найденно контрагентов в базе");
            Customer customer = repository.FindBy(customers[0].Key);
            Assert.IsNotNull(customer);
        }

        [TestMethod()]
        public void FindByIdCustomer()
        {
            IList<Customer> customers = repository.FindAll();
            Assert.IsTrue(customers.Count > 0, "Не найденно контрагентов в базе");
            Customer customer = repository.FindById(customers[0].Id);
            Assert.IsNotNull(customer);
        }

        [TestMethod()]
        public void ChangeCustomer()
        {
            IList<Customer> customers = repository.FindAll();
            Assert.IsTrue(customers.Count > 0, "Не найденно контрагентов в базе");
            Customer customer = repository.FindBy(customers[0].Key);

            string testName = customer.Name + "_changed";
            customer.Name = testName;
            repository[customer.Key] = customer;
            repository.Save();

            Customer changedCustomer = repository.FindBy(customer.Key);
            Assert.AreEqual(changedCustomer.Name, testName);
        }

        [TestMethod()]
        public void DeleteCustomer()
        {
            IList<Customer> customers = repository.FindAll();
            int countOldCustomers = customers.Count;
            Assert.IsTrue(customers.Count > 0, "Не найденно контрагентов в базе");
            
            Customer customer = repository.FindBy(customers[0].Key);
            repository.Remove(customer);
            repository.Save();
            
            int currentCountCusotmers = repository.FindAll().Count;
            Assert.AreEqual(currentCountCusotmers, countOldCustomers - 1);
        }
    }
}
