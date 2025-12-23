
using System;
using System.Collections.Generic;

namespace Tyuiu.RogozinaMA.Sprint7.Project.V12.Lib
{
    public class DataService
    {
        // Класс для компьютеров
        public class Computer
        {
            public string Manufacturer { get; set; } = "";
            public string ProcessorType { get; set; } = "";
            public double ClockSpeed { get; set; } // GHz
            public int RAM { get; set; } // GB
            public int HDD { get; set; } // GB
            public DateTime ReleaseDate { get; set; }

            public Computer() { }
        }




        // Тестовые данные для компьютеров
        public List<Computer> GetTestComputers()
        {
            return new List<Computer>
            {
                new Computer { Manufacturer = "Dell", ProcessorType = "Intel i5", ClockSpeed = 3.2, RAM = 8, HDD = 512, ReleaseDate = new DateTime(2023, 5, 15) },
                new Computer { Manufacturer = "HP", ProcessorType = "AMD Ryzen 7", ClockSpeed = 3.8, RAM = 16, HDD = 1000, ReleaseDate = new DateTime(2023, 8, 20) },
                new Computer { Manufacturer = "Lenovo", ProcessorType = "Intel i7", ClockSpeed = 4.0, RAM = 32, HDD = 2000, ReleaseDate = new DateTime(2023, 10, 10) },
                new Computer { Manufacturer = "Apple", ProcessorType = "M2 Pro", ClockSpeed = 3.5, RAM = 16, HDD = 512, ReleaseDate = new DateTime(2023, 1, 24) },
                new Computer { Manufacturer = "Asus", ProcessorType = "Intel i9", ClockSpeed = 5.0, RAM = 64, HDD = 4000, ReleaseDate = new DateTime(2023, 12, 5) }
            };
        }

        public List<Computer> SearchComputers(List<Computer> computers, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return computers;

            var results = new List<Computer>();
            foreach (var comp in computers)
            {
                if (comp.Manufacturer.ToLower().Contains(searchText.ToLower()) ||
                    comp.ProcessorType.ToLower().Contains(searchText.ToLower()))
                {
                    results.Add(comp);
                }
            }
            return results;
        }

        public List<Computer> FilterComputers(List<Computer> computers, int minRAM, int maxRAM, int minHDD, int maxHDD)
        {
            var filtered = new List<Computer>();
            foreach (var comp in computers)
            {
                if (comp.RAM >= minRAM && comp.RAM <= maxRAM &&
                    comp.HDD >= minHDD && comp.HDD <= maxHDD)
                {
                    filtered.Add(comp);
                }
            }
            return filtered;
        }

    }
}