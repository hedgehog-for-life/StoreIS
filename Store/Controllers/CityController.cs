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
    class CityController
    {
        private CityRepository cityRepository;

        public CityController(stuff_shopContext db)
        {
            cityRepository = new CityRepository(db);
        }

        public City GetCity(int id)
        {
            return cityRepository.Get(id);
        }

        public City GetCity(string name, Region region)
        {
            return cityRepository.GetByName(name, region);
        }

        public void AddCity(City city)
        {
            cityRepository.Add(city);
        }

        public void AddDetachedCity(City city)
        {
            cityRepository.AddDetached(city);
        }

        public List<City> GetCities()
        {
            return cityRepository.Items.ToList();
        }

        public List<City> GetCitiesByRegion(Region region)
        {
            return cityRepository.GetCitiesByRegion(region).ToList();
        }
    }
}
