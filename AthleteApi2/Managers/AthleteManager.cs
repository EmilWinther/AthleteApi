using System;
using System.Collections.Generic;
using AthleteLibrary;

namespace AthleteApi2.Controllers
{
    public class AthleteManager
    {
        private static int _nextId = 1;

        private static readonly List<Athlete> Data = new List<Athlete>
        {
            new Athlete(_nextId++, "Niels  Nielsen",  "Japan", 190),
            new Athlete(_nextId++, "John Jackson", "Denmark", 165),
            new Athlete(_nextId++, "Kyoab Naini", "Sweden", 145),
            new Athlete(_nextId++, "Hanne Larsen", "Denmark", 210),
            new Athlete(_nextId++, "Ryan Hansen", "America", 185)
        };

        public IEnumerable<Athlete> GetAllAthletes()
        {
            return new List<Athlete>(Data);
        }

        public Athlete GetById(int id)
        {
            return Data.Find(athlete => athlete.Id == id);
        }


        public List<Athlete> GetByCountry(string country)
        {
            List<Athlete> result = new List<Athlete>(Data);
            if (country != null)
            {
                result = result.FindAll(data => data.Country.Contains(country, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }
        public Athlete Add(Athlete athlete)
        {
            athlete.Id = _nextId++;
            Data.Add(athlete);
            return athlete;
        }

        public Athlete Delete(int id)
        {
            Athlete athlete = Data.Find(athlete => athlete.Id == id);
            if (athlete == null) return null;
            Data.Remove(athlete);
            return athlete;
        }
    }
}