using Microsoft.EntityFrameworkCore;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.DataBase.Repositories
{
    class CityRepository : DbRepository<City> , IEntityRepository<City>
    {
        public override IQueryable<City> Items => base.Items.Include(item => item.Region);

        public CityRepository(stuff_shopContext db) : base(db) { }

        public City Get(int id) => Items.SingleOrDefault(city => city.Id == id);
        public async Task<City> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(city => city.Id == id, Cancel)
           .ConfigureAwait(false);

        public City GetByName(string name, Region region)
        {
            City result = Items.SingleOrDefault(city => city.CityName == name && city.Region == region);
            if(result != null)
            _db.Entry(result).State = EntityState.Detached;
            return result;
        }

        public IQueryable<City> GetCitiesByRegion(Region region) => Items.Where(city => city.Region == region);


            public void Remove(int id)
        {
            var city = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new City { Id = id };
            _db.Remove(city);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new City { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
