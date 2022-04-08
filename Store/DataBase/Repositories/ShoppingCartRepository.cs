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
    class ShoppingCartRepository : DbRepository<ShoppingCart> , IEntityRepository<ShoppingCart>
    {
        public override IQueryable<ShoppingCart> Items => base.Items
            .Include(item => item.Good)
            .Include(item => item.User)
            ;

        public ShoppingCartRepository(stuff_shopContext db) : base(db) { }

        public ShoppingCart Get(int id) => Items.SingleOrDefault(shoppingCart => shoppingCart.Id == id);
        public async Task<ShoppingCart> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(shoppingCart => shoppingCart.Id == id, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var shoppingCart = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new ShoppingCart { Id = id };
            _db.Remove(shoppingCart);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new ShoppingCart { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public ShoppingCart Get(int userId, int goodId) => Items.FirstOrDefault(shoppingCat => shoppingCat.GoodId == goodId && shoppingCat.UserId == userId);

        public IQueryable<ShoppingCart> GetByUser(Person user) => Items.Where(shoppingCart => shoppingCart.User == user);

    }
}
