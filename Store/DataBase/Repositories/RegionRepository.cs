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
    class RegionRepository : DbRepository<Region> , IEntityRepository<Region>
    {
        public override IQueryable<Region> Items => base.Items.Include(item => item.Country);

        public RegionRepository(stuff_shopContext db) : base(db) { }

        public Region Get(int id) => Items.SingleOrDefault(region => region.Id == id);
        public async Task<Region> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(region => region.Id == id, Cancel)
           .ConfigureAwait(false);

        public Region GetByName(string name, Country country)
        {
            Region result = Items.SingleOrDefault(region => region.RegionName == name && region.Country == country);
            if(result != null)
            _db.Entry(result).State = EntityState.Detached;
            return result;

        }


            public void Remove(int id)
        {
            var region = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Region { Id = id };
            _db.Remove(region);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Region { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
