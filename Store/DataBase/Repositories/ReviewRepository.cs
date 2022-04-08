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
    class ReviewRepository : DbRepository<Review> , IEntityRepository<Review>
    {
        public override IQueryable<Review> Items => base.Items
            .Include(item => item.Good)
            .Include(item => item.User)
            ;

        public ReviewRepository(stuff_shopContext db) : base(db) { }

        public Review Get(int id) => Items.SingleOrDefault(review => review.Id == id);
        public async Task<Review> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(review => review.Id == id, Cancel)
           .ConfigureAwait(false);

        public IQueryable<Review> GetByGood(Good good) => Items.Where(review => review.Good == good);

        public void Remove(int id)
        {
            var review = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Review { Id = id };
            _db.Remove(review);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Review { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
