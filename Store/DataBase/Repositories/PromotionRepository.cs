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
    class PromotionRepository : DbRepository<Promotion> , IEntityRepository<Promotion>
    {
        public PromotionRepository(stuff_shopContext db) : base(db) { }

        public Promotion Get(int id) => Items.SingleOrDefault(promotion => promotion.Id == id);
        public async Task<Promotion> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(promotion => promotion.Id == id, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var promotion = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Promotion { Id = id };
            _db.Remove(promotion);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Promotion { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public IQueryable<Promotion> GetCurrent() => Items.Where(promotion => promotion.DateEnd >= DateTime.Now);
    }
}
