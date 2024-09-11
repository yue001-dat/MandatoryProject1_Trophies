namespace MandatoryProject1_Trophies
{
    public class Trophy
    {
        // Properties
        public int Id {  get; set; }
        public string Competition { get; set; } = "Athletics";
        public int Year { get; set; }

        /**
         * Validators
         **/
        // Validate Competition
        public void validateCompetition()
        {
            if (Competition == null)
            {
                throw new ArgumentNullException("Competition cannot be null.");
            }

            if(Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition must be at least 3 characters long.");
            }
        }

        // Validate Year
        public void validateYear()
        {
            if(Year < 1970)
            {
                throw new ArgumentOutOfRangeException("Year cannot be below 1970");
            }

            if (Year > 2024)
            {
                throw new ArgumentOutOfRangeException("Year cannot exceed 2024");
            }
        }

        // Validate All
        public void validate()
        {
            validateCompetition();
            validateYear();
        }

        // ToString Method
        public override string ToString()
        {
            return Id + " " + Competition + " " + Year;
        }



    }
}
