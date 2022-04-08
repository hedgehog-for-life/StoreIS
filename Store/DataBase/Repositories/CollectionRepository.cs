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
    class CollectionRepository : DbRepository<Collection> , IEntityRepository<Collection>
    {
        public CollectionRepository(stuff_shopContext db) : base(db) { }

        public Collection Get(int id) => Items.SingleOrDefault(collection => collection.Id == id);
        public async Task<Collection> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(collection => collection.Id == id, Cancel)
           .ConfigureAwait(false);

        public Collection GetByName(string name) => Items.SingleOrDefault(collection => collection.ColName == name);
        public async Task<Collection> GetByNameAsync(string name, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(collection => collection.ColName == name, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var collection = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Collection { Id = id };
            _db.Remove(collection);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Collection { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public IQueryable<Collection> GetActive() => Items.Where(collection => collection.ColStatus != 0);

        public IQueryable<Collection> GetLikeName(string name) => Items.Where(collection => collection.ColStatus > 0 && EF.Functions.Like(collection.ColName, "%" + name + "%"));
    }
}
