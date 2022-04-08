using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class OrderGoodController
    {
        private OrderGoodRepository orderGoodRepository;

        public OrderGoodController(stuff_shopContext db)
        {
            orderGoodRepository = new OrderGoodRepository(db);
        }

        public List<Good> GetGoods(Order o)
        {
            List<OrderGood> items = orderGoodRepository.GetByOrder(o).ToList<OrderGood>();
            List<Good> goods = new List<Good>();
            foreach (OrderGood gp in items)
                goods.Add(gp.Good);
            return goods;
        }

        public List<OrderGood> GetOrderGoodsByOrder(Order order)
        {
            return orderGoodRepository.GetByOrder(order).ToList<OrderGood>(); ;
        }

        async public Task AddGoodOrderAsync(OrderGood orderGood)
        {
           await  orderGoodRepository.AddAsync(orderGood, new System.Threading.CancellationToken());
        }

        public void AddGoodOrder(OrderGood orderGood)
        {
            orderGoodRepository.Add(orderGood);
        }
    }
}
