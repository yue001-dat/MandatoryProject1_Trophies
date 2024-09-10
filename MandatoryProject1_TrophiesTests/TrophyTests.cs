namespace MandatoryProject1_Trophies.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        private Trophy Trophy = new Trophy();

        [TestMethod()]
        public void StringCompetitionIsNull_ThrowException()
        {
            Trophy.Competition = null;

            Assert.ThrowsException<ArgumentNullException>(() => Trophy.validateCompetition());
        }
       

        [TestMethod()]
        public void StringCompetitionLenghtIsOutOfRange_ThrowException()
        {
            Trophy.Competition = "At";

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Trophy.validateCompetition());
        }

       
        [TestMethod()]
        public void IntYearIsOutOfUpperRange_ThrowException()
        {
            Trophy.Year = 2025;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Trophy.validateYear());
        }
        

        [TestMethod()]
        public void IntYearIsOutOfLowerRange_ThrowException()
        {
            Trophy.Year = 1969;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Trophy.validateYear());
        }        
    }
}