using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.RogozinaMA.Sprint7.Project.V12.Lib;

namespace Tyuiu.RogozinaMA.Sprint7.Project.V12.Test
{
    [TestClass]
    public class DataServiceTest
    {

        [TestMethod]
        public void TestGetTestComputers()
        {
            DataService ds = new DataService();
            var computers = ds.GetTestComputers();
            Assert.AreEqual(3, computers.Count);
        }

        [TestClass]
        public class DataServiceTests
        {
            [TestMethod]
            public void TestSearchComputers_Found()
            {
                // Arrange
                var computers = new List<DataService.Computer>
        {
            new DataService.Computer { Manufacturer = "Asus", ProcessorType = "Intel i5" }
        };
                var service = new DataService();

                // Act
                var result = service.SearchComputers(computers, "asus");

                // Assert
                Assert.AreEqual(1, result.Count);
            }

            [TestMethod]
            public void TestFilterComputers_CorrectFiltering()
            {
                // Arrange
                var computers = new List<DataService.Computer>
        {
            new DataService.Computer { RAM = 8, HDD = 256 },
            new DataService.Computer { RAM = 16, HDD = 512 }
        };
                var service = new DataService();

                // Act
                var result = service.FilterComputers(computers, 10, 20, 200, 300);

                // Assert
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(16, result[0].RAM);
            }
        }
    }
}