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
    class OrderRepository : DbRepository<Order> , IEntityRepository<Order>
    {
        public override IQueryable<Order> Items => base.Items
            .Include(item => item.User)
            .Include(item => item.Courier)
            .Include(item => item.Address)
          //  .Include(item => item.OrderGood)
            ;

        public OrderRepository(stuff_shopContext db) : base(db) { }

        public Order Get(int id) => Items.SingleOrDefault(order => order.Id == id);
        public async Task<Order> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(order => order.Id == id, Cancel)
           .ConfigureAwait(false);

        public IQueryable<Order> GetStatusWait(int courierId) => Items.Where(order => order.DeliveryMethod == 0 && (order.OrderStatus == 0 ||
        order.OrderStatus == 1 && order.CourierId == courierId));

        public IQueryable<Order> GetForCurrentCourier(int courierId) => Items.Where(order => order.DeliveryMethod == 0 && order.OrderStatus >= 2 && order.OrderStatus < 7 && order.CourierId == courierId);

        public void Remove(int id)
        {
            var order = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Order { Id = id };
            _db.Remove(order);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Order { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public IQueryable<Order> GetUserCurrentOrders(Person user) => Items.Where(order => order.DeliveryMethod == 0 && order.User == user && order.OrderStatus != 7 && order.Verified == false
                                                                    || order.DeliveryMethod == 1 && order.User == user && order.OrderStatus != 5 && order.Verified == false);

        public IQueryable<Order> GetUserArchivedOrders(Person user) => Items.Where(order => order.DeliveryMethod == 0 && order.User == user && order.OrderStatus == 6 && order.Verified == true
                                                                    || order.DeliveryMethod == 1 && order.User == user && order.OrderStatus == 4 && order.Verified == true);
    }
}
