using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryProject1_Trophies;

namespace MandatoryProject1_Trophies.Tests
{
    [TestClass()]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository repository;

        public TrophiesRepositoryTests()
        {
            repository = new TrophiesRepository();
        }

        // Method 1: GetById
        [TestMethod()]
        public void Get_TrophyById_ReturnTrophyObject()
        {
            Trophy trophy = repository.GetById(1); // Existing ID

            Assert.AreEqual(1, trophy.Id);
        }

        [TestMethod()]
        public void Get_TrophyById_ReturnNull()
        {
            Trophy trophy = repository.GetById(99); // Non existing ID

            Assert.IsNull(trophy, "No such trophy found for id " + 99);
        }


        // Method 2: Add       
        [TestMethod()]
        public void Add_Trophy_ReturnTrophyObject()
        {
            Trophy trophy = repository.Add(new Trophy() { Competition = "Fencing", Year = 2024 });

            Assert.AreEqual(6, trophy.Id);
        }


        // Method 3: Remove
        [TestMethod()]
        public void Remove_Trophy_ReturnTrophyObject()
        {
            Trophy trophy = repository.Add(new Trophy() { Competition = "Golf", Year = 2024 });

            Assert.IsNotNull(repository.Remove(trophy.Id));

        }

        [TestMethod()]
        public void Remove_Trophy_ReturnNull()
        {
            Trophy trophy = repository.Add(new Trophy() { Competition = "Golf", Year = 2024 });

            Assert.IsNull(repository.Remove(trophy.Id++), "No such trophy found for id " + trophy.Id);
        }


        // Method 4: Get (Filter and Sort)
        [TestMethod()]
        public void Get_FilteredByYearTrophyList_ReturnFilteredList()
        {
            List<Trophy> filteredTrophy = repository.Get(2020);

            Assert.AreEqual(2020, filteredTrophy[0].Year);
            Assert.AreEqual(1, filteredTrophy.Count());
        }

        [TestMethod()]
        public void Get_SortByYearTrophyList_ReturnSortedList()
        {
            int[] expectedYearOrder = { 2024, 2023, 2022, 2021, 2020 };
            List<Trophy> orderedTrophy = repository.Get(sortBy: "year");

            for (int i = 0; i < expectedYearOrder.Length; i++)
            {
                Assert.AreEqual(expectedYearOrder[i], orderedTrophy[i].Year);
            }
        }
    }
}