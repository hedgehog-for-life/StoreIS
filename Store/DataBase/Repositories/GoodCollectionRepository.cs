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
    class GoodCollectionRepository : DbRepository<GoodCollection> , IConnectorRepository<GoodCollection>
    {
        public override IQueryable<GoodCollection> Items => base.Items
            .Include(item => item.Good)
            .Include(item => item.Col)
            ;

        public GoodCollectionRepository(stuff_shopContext db) : base(db) { }

        public GoodCollection Get(int key1, int key2)
        {
            GoodCollection result = Items.SingleOrDefault(
            goodCollection => goodCollection.GoodId == key1 && goodCollection.ColId == key2);

            if(result != null)
            _db.Entry(result).State = EntityState.Detached;

            return result;

        }
        public async Task<GoodCollection> GetAsync(int key1, int key2, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(
            goodCollection => goodCollection.GoodId == key1 && goodCollection.ColId == key2, 
            Cancel)
           .ConfigureAwait(false);

        public IQueryable<GoodCollection> GetByCollection(Collection collection) => Items.Where(goodCol => goodCol.Col == collection);

        public void Remove(int key1, int key2)
        {
            var goodCollection = _Set.Local.FirstOrDefault(i => i.GoodId == key1 && i.ColId == key2) 
                ?? new GoodCollection { GoodId = key1, ColId = key2 };
            _db.Remove(goodCollection);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int key1, int key2, CancellationToken Cancel = default)
        {
            _db.Remove(new GoodCollection { GoodId = key1, ColId = key2 }) ;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public async Task RemoveAsync(GoodCollection goodCollection, CancellationToken Cancel = default)
        {
            _db.Remove(goodCollection);
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
