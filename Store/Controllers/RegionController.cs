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
    class RegionController
    {
        private RegionRepository regionRepository;

        public List<Region> GetRegions()
        {
            return regionRepository.Items.ToList();
        }

        public RegionController(stuff_shopContext db)
        {
            regionRepository = new RegionRepository(db);
        }

        public Region GetRegion(int id)
        {
            return regionRepository.Get(id);
        }

        public Region GetRegion(string name, Country country)
        {
            return regionRepository.GetByName(name, country);
        }

        public void AddRegion(Region region)
        {
            regionRepository.Add(region);
        }

        public void AddDetachedRegion(Region region)
        {
            regionRepository.AddDetached(region);
        }
    }
}
