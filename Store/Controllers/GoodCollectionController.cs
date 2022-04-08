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
    class GoodCollectionController
    {
        private GoodCollectionRepository goodCollectionRepository;

        public GoodCollectionController(stuff_shopContext db)
        {
            goodCollectionRepository = new GoodCollectionRepository(db);
        }

        public List<Good> GetGoods(Collection c)
        {
            List<GoodCollection> items = goodCollectionRepository.GetByCollection(c).ToList<GoodCollection>();
            List<Good> goods = new List<Good>();
            foreach (GoodCollection gc in items)
                goods.Add(gc.Good);
            return goods;
        }

        public GoodCollection GetGoodCollection(int goodId, int collectionId)
        {
            return goodCollectionRepository.Get(goodId, collectionId);
        }

        async public Task AddGoodCollectionAsync(Good good, Collection collection)
        {
            GoodCollection goodCollection = new GoodCollection();
            goodCollection.Good = good;
            goodCollection.Col = collection;

            await goodCollectionRepository.AddAsync(goodCollection, new System.Threading.CancellationToken());
        }

        async public Task RemoveGoodCollectionAsync(Good good, Collection collection)
        {
            GoodCollection goodCollection = new GoodCollection();
            goodCollection.Good = good;
            goodCollection.Col = collection;

            await goodCollectionRepository.RemoveAsync(goodCollection, new System.Threading.CancellationToken());
        }
    }
}
