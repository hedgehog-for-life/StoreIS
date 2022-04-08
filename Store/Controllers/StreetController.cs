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
    class StreetController
    {
        private StreetRepository streetRepository;

        public StreetController(stuff_shopContext db)
        {
            streetRepository = new StreetRepository(db);
        }

        public Street GetStreet(int id)
        {
            return streetRepository.Get(id);
        }

        public Street GetStreet(string name, City city)
        {
            return streetRepository.GetByName(name, city);
        }

        public void AddDetachedStreet(Street street)
        {
            streetRepository.AddDetached(street);
        }

        public void AddStreet(Street street)
        {
            streetRepository.Add(street);
        }
    }
}
