using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class CountryController
    {
        private CountryRepository countryRepository;

        public CountryController(stuff_shopContext db)
        {
            countryRepository = new CountryRepository(db);
        }

        public List<Country> GetCountries()
        {
            return countryRepository.Items.ToList(); ;
        }

        public Country GetCountry(int id)
        {
            return countryRepository.Get(id);
        }

        public Country GetCountry(string name)
        {
            return countryRepository.GetByName(name);
        }

        public void AddCountry(Country country)
        {
            countryRepository.Add(country);
        }
    }
}
