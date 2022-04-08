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
    class OrderController
    {
        private OrderRepository orderRepository;
        public OrderController(stuff_shopContext db)
        {
            orderRepository = new OrderRepository(db);
        }

        public List<Order> GetOrders()
        {
            List<Order> items = orderRepository.Items.ToList<Order>();
            return items;
        }

        public List<Order> GetAwaitingCourier(int courierId)
        {
            List<Order> items = orderRepository.GetStatusWait(courierId).ToList<Order>();
            return items;
        }

        public List<Order> GetCurrentCourierOrders(int courierId)
        {
            List<Order> items = orderRepository.GetForCurrentCourier(courierId).ToList<Order>();
            return items;
        }

        public void RemoveOrder(int id)
        {
            orderRepository.Remove(id);
        }

        async public Task UpdateOrderAsync(Order order)
        {
            await orderRepository.UpdateAsync(order, new System.Threading.CancellationToken());
        }

        public void UpdateOrder(Order order)
        {
            orderRepository.Update(order);
        }

        public void AddOrder(Order order)
        {
            orderRepository.Add(order);
        }

        public List<Order> GetUserCurrentOrders(Person user)
        {
            return orderRepository.GetUserCurrentOrders(user).ToList();
        }

        public List<Order> GetUserArchivedOrders(Person user)
        {
            return orderRepository.GetUserArchivedOrders(user).ToList() ;
        }
    }
}
 