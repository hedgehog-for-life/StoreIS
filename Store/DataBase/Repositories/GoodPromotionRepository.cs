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
    class GoodPromotionRepository : DbRepository<GoodPromotion> , IConnectorRepository<GoodPromotion>
    {
        public override IQueryable<GoodPromotion> Items => base.Items
            .Include(item => item.Good)
            .Include(item => item.Promotion)
            ;

        public GoodPromotionRepository(stuff_shopContext db) : base(db) { }

        public GoodPromotion Get(int key1, int key2) => Items.SingleOrDefault(
            goodPromotion => goodPromotion.GoodId == key1 && goodPromotion.PromotionId == key2);
        public async Task<GoodPromotion> GetAsync(int key1, int key2, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(
            goodPromotion => goodPromotion.GoodId == key1 && goodPromotion.PromotionId == key2,
            Cancel)
           .ConfigureAwait(false);

        public IQueryable<GoodPromotion> GetByPromotion(Promotion promotion) => Items.Where(goodPromotion => goodPromotion.Promotion == promotion);

        public IQueryable<GoodPromotion> GetByGood(Good good) => Items.Where(goodPromotion => goodPromotion.Good == good);

        public void Remove(int key1, int key2)
        {
            var goodPromotion = _Set.Local.FirstOrDefault(i => i.GoodId == key1 && i.PromotionId == key2)
                ?? new GoodPromotion { GoodId = key1, PromotionId = key2 };
            _db.Remove(goodPromotion);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int key1, int key2, CancellationToken Cancel = default)
        {
            _db.Remove(new GoodPromotion { GoodId = key1, PromotionId = key2 });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public async Task RemoveAsync(GoodPromotion goodPromotion, CancellationToken Cancel = default)
        {
            _db.Remove(goodPromotion);
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
