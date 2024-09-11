namespace MandatoryProject1_Trophies
{
    public class TrophiesRepository
    {
        // Properties
        public int nextId = 1;
        private List<Trophy> trophies = new List<Trophy>();

        public TrophiesRepository() 
        {
            // Source: https://olympics.com/en/sports/
            Trophy trophy1 = new Trophy { Year = 2020, Competition = "Acrobatic Gymnastics" };
            Trophy trophy2 = new Trophy { Year = 2021, Competition = "Badminton" };
            Trophy trophy3 = new Trophy { Year = 2022, Competition = "Canoe Slalom" };
            Trophy trophy4 = new Trophy { Year = 2023, Competition = "Diving" };
            Trophy trophy5 = new Trophy { Year = 2024, Competition = "Equestrian" };

            Add(trophy1);
            Add(trophy2);
            Add(trophy3);
            Add(trophy4);
            Add(trophy5); 
        }


        /**
         * Methods
         **/
        public List<Trophy> Get(int ?Year = null, string ?sortBy = null) 
        {
            List<Trophy> list = new List<Trophy>(trophies);

            // Filter by Year
            if(Year != null) {
                list = list.Where(item => item.Year == Year).ToList();
            }

            // Sort by Year or Competition (ASC)
            if(sortBy != null)
            {
                if(sortBy == "competition")
                {
                    list = list.OrderBy(item => item.Competition).ToList();
                }
                
                if(sortBy == "year")
                {
                    list = list.OrderBy(item => item.Year).ToList();
                }
            }

            // Return List
            return list;
        }

        public Trophy? GetById(int id)
        {
            return trophies.FirstOrDefault(t => t.Id == id);
        }

        public Trophy? Add(Trophy trophy)
        {
            trophy.validate();
            trophy.Id = nextId++;
            trophies.Add(trophy);

            return trophy;
        }

        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            
            if (trophy == null)
            {
                return null;
            }

            trophies.Remove(trophy);

            return trophy;
        }

        public Trophy? Update(int id, Trophy values)
        {
            values.validate();

            Trophy? targetTrophy = GetById(id);

            if (targetTrophy == null)
            {
                return null;
            }

            targetTrophy.Competition    = values.Competition;
            targetTrophy.Year           = values.Year;

            return targetTrophy;
        }
    }
}
