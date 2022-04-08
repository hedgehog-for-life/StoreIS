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
    class ShoppingCartController
    {
        private ShoppingCartRepository shoppingCartRepository;

        public ShoppingCartController(stuff_shopContext db)
        {
            shoppingCartRepository = new ShoppingCartRepository(db);
        }

        public ShoppingCart GetBYUserAndGood(int userId, int goodId)
        {
            return shoppingCartRepository.Get(userId, goodId);
        }

        async public Task AddItemAsync(ShoppingCart item)
        {
            await shoppingCartRepository.AddAsync(item, new System.Threading.CancellationToken());
        }

        public List<ShoppingCart> GetShoppingCarts(Person user) 
        {
            return shoppingCartRepository.GetByUser(user).ToList();
        }

        async public  Task UpdateItemAsync(ShoppingCart item)
        {
            await shoppingCartRepository.UpdateAsync(item, new System.Threading.CancellationToken());
        }

        async public Task RemoveItemAsync(int id)
        {
            await shoppingCartRepository.RemoveAsync(id);
        }

        public void RemoveItem(int id)
        {
            shoppingCartRepository.Remove(id);
        }

    }
}
