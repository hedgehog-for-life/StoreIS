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
    class CountryRepository : DbRepository<Country>, IEntityRepository<Country>
    {
        public CountryRepository(stuff_shopContext db) : base(db) { }

        public Country Get(int id) => Items.SingleOrDefault(country => country.Id == id);
        public async Task<Country> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(country => country.Id == id, Cancel)
           .ConfigureAwait(false);

        public Country GetByName(string name) => Items.SingleOrDefault(country => country.CountryName == name);

        public void Remove(int id)
        {
            var country = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Country { Id = id };
            _db.Remove(country);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Country { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
