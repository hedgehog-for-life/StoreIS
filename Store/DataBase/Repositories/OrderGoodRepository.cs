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
    class OrderGoodRepository : DbRepository<OrderGood> , IConnectorRepository<OrderGood>
    {
        public override IQueryable<OrderGood> Items => base.Items
            .Include(item => item.Order)
            .Include(item => item.Good)
            ;

        public OrderGoodRepository(stuff_shopContext db) : base(db) { }

        public OrderGood Get(int key1, int key2) => Items.SingleOrDefault(
            orderGood => orderGood.OrderId == key1 && orderGood.GoodId == key2);
        public async Task<OrderGood> GetAsync(int key1, int key2, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(
            orderGood => orderGood.OrderId == key1 && orderGood.GoodId == key2,
            Cancel)
           .ConfigureAwait(false);

        public IQueryable<OrderGood> GetByOrder(Order order) => Items.Where(orderGood => orderGood.Order == order);

        public void Remove(int key1, int key2)
        {
            var orderGood = _Set.Local.FirstOrDefault(i => i.OrderId == key1 && i.GoodId == key2)
                ?? new OrderGood { OrderId = key1, GoodId = key2 };
            _db.Remove(orderGood);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int key1, int key2, CancellationToken Cancel = default)
        {
            _db.Remove(new OrderGood { OrderId = key1, GoodId = key2 });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
