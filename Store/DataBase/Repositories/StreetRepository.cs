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
    class StreetRepository : DbRepository<Street> , IEntityRepository<Street>
    {
        public override IQueryable<Street> Items => base.Items.Include(item => item.City);

        public StreetRepository(stuff_shopContext db) : base(db) { }

        public Street Get(int id) {
            Street result = Items.SingleOrDefault(street => street.Id == id);
            _db.Entry(result).State = EntityState.Detached;

            return result;
        }
        public async Task<Street> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(street => street.Id == id, Cancel)
           .ConfigureAwait(false);

        public Street GetByName(string name, City city)
        {
            Street result = Items.SingleOrDefault(street => street.StreetName == name && street.City == city);
            if(result != null)
                _db.Entry(result).State = EntityState.Detached;

            return result;
        }

        public void Remove(int id)
        {
            var street = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Street { Id = id };
            _db.Remove(street);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Street { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
