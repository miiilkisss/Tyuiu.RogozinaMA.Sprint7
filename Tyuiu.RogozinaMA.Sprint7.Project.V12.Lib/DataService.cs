using System;
using System.Collections.Generic;

namespace Tyuiu.RogozinaMA.Sprint7.Project.V12.Lib
{
    public class DataService
    {
        public class Computer
        {
            public string Manufacturer { get; set; } = "";
            public string ProcessorType { get; set; } = "";
            public double ClockSpeed { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public DateTime ReleaseDate { get; set; }

            public Computer() { }

            public Computer(string manufacturer, string processorType, double clockSpeed,
                           int ram, int hdd, DateTime releaseDate)
            {
                Manufacturer = manufacturer;
                ProcessorType = processorType;
                ClockSpeed = clockSpeed;
                RAM = ram;
                HDD = hdd;
                ReleaseDate = releaseDate;
            }
        }

        // Поиск
        public List<Computer> SearchComputers(List<Computer> computers, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return computers;

            return computers.Where(c =>
                c.Manufacturer.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.ProcessorType.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.RAM.ToString().Contains(searchTerm)).ToList();
        }

        // Сортировка
        public List<Computer> SortComputers(List<Computer> computers, string sortBy, bool ascending = true)
        {
            switch (sortBy.ToLower())
            {
                case "производитель":
                case "manufacturer":
                    return ascending ?
                        computers.OrderBy(c => c.Manufacturer).ToList() :
                        computers.OrderByDescending(c => c.Manufacturer).ToList();

                case "озу":
                case "ram":
                    return ascending ?
                        computers.OrderBy(c => c.RAM).ToList() :
                        computers.OrderByDescending(c => c.RAM).ToList();

                case "hdd":
                    return ascending ?
                        computers.OrderBy(c => c.HDD).ToList() :
                        computers.OrderByDescending(c => c.HDD).ToList();

                case "частота":
                case "clockspeed":
                    return ascending ?
                        computers.OrderBy(c => c.ClockSpeed).ToList() :
                        computers.OrderByDescending(c => c.ClockSpeed).ToList();

                default:
                    return computers;
            }
        }

        // Фильтрация
        public List<Computer> FilterComputers(List<Computer> computers, int minRAM, int maxRAM, int minHDD, int maxHDD)
        {
            return computers.Where(c =>
                c.RAM >= minRAM && c.RAM <= maxRAM &&
                c.HDD >= minHDD && c.HDD <= maxHDD).ToList();
        }

        public List<Computer> GetTestComputers()
        {
            return new List<Computer>
            {
                new Computer("Apple", "M2", 3.5, 16, 512, new DateTime(2023, 6, 15)),
                new Computer("Dell", "Intel i5", 3.2, 8, 512, new DateTime(2023, 1, 15)),
                new Computer("HP", "AMD Ryzen 5", 3.6, 16, 1000, new DateTime(2023, 3, 20)),
                new Computer("Lenovo", "Intel i7", 4.0, 32, 2000, new DateTime(2023, 5, 10)),
                new Computer("Asus", "AMD Ryzen 7", 3.8, 16, 1000, new DateTime(2023, 4, 25)),
                new Computer("Acer", "Intel i3", 2.8, 4, 256, new DateTime(2022, 11, 30)),
                new Computer("MSI", "Intel i9", 5.0, 64, 4000, new DateTime(2023, 6, 15))
            };
        }
    }
}