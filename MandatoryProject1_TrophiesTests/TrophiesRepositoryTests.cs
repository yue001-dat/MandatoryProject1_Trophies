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


  
       
    }
}