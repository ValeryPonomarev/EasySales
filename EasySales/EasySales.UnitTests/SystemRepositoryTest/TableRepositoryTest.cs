using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasySales.Model.System;
using EasySales.Infrastructure.RepositoryFramework;

namespace EasySales.UnitTests.SystemRepositoryTest
{
    /// <summary>
    /// Сводное описание для TableRepositoryTest
    /// </summary>
    [TestClass]
    public class TableRepositoryTest
    {
        private TestContext testContextInstance;
        private ITableRepository repository;
        private const string testTableName = "UnitTestTable";

        public TableRepositoryTest()
        {
            repository = EFRepositoryFactory.GetRepository<ITableRepository, Table>() as ITableRepository;
        }

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
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

        [TestCleanup()]
        public void MyTestCleanup() {
            Table table = repository.FindByName(testTableName);
            if(table != null) {
                repository.Remove(table);
            }
        }

        [TestMethod]
        public void ExistsTableRepository()
        {
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void AddTable()
        {
            int countTables = repository.FindAll().Count;
            Table table = new Table();
            table.Name = testTableName;
            repository.Add(table);
            repository.Save();
            int currentCountTables = repository.FindAll().Count;
            Assert.AreEqual(countTables, currentCountTables - 1);
        }

        [TestMethod]
        public void GetAllTables()
        {
            Table table = new Table();
            table.Name = testTableName;
            repository.Add(table);
            repository.Save();
            Assert.IsTrue(TableService.GetAll().Count > 0);
        }

        [TestMethod]
        public void FindTableByName()
        {
            Table table = new Table();
            table.Name = testTableName;
            repository.Add(table);
            repository.Save();
            Assert.IsNotNull(repository.FindByName(testTableName));
        }

        [TestMethod]
        public void FindTableByKey()
        {
            Table findTable = null;
            Guid key = Guid.Empty;
            Table table = new Table();
            key = table.Key;
            table.Name = testTableName;
            repository.Add(table);
            repository.Save();
            findTable = repository.FindBy(key);
            Assert.IsNotNull(findTable);
        }

        [TestMethod]
        public void FindTableByID()
        {
            Table table = new Table();
            table.Name = testTableName;
            repository.Add(table);
            repository.Save();

            IList<Table> tables = repository.FindAll();
            Assert.IsTrue(tables.Count > 0, "Не найденно таблиц в базе");
            table = repository.FindById(tables[0].Id);
            Assert.IsNotNull(table);
        }

        [TestMethod]
        public void ChangeTable()
        {
            Guid key = Guid.Empty;

            Table table = new Table();
            key = table.Key;
            table.Name = testTableName + "_1";
            repository.Add(table);
            repository.Save();

            table.Name = testTableName;
            repository[table.Key] = table;
            repository.Save();
            Table changedTable = repository.FindBy(key);
            Assert.AreEqual(testTableName, changedTable.Name);
        }

        [TestMethod]
        public void RemoveTable()
        {
            Table table = new Table();
            table.Name = testTableName;
            repository.Add(table);
            repository.Save();
            int countTables = repository.FindAll().Count;
            repository.Remove(table);
            repository.Save();
            int currentCountTables = repository.FindAll().Count;
            Assert.AreEqual(countTables, currentCountTables + 1);
        }
    }
}
