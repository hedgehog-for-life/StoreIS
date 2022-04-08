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
    class GoodPromotionController
    {
        private GoodPromotionRepository goodPromotionRepository;
        public GoodPromotionController(stuff_shopContext db)
        {
            goodPromotionRepository = new GoodPromotionRepository(db);
        }

        public List<Good> GetGoods(Promotion p)
        {
            List<GoodPromotion> items = goodPromotionRepository.GetByPromotion(p).ToList<GoodPromotion>();
            List<Good> goods = new List<Good>();
            foreach (GoodPromotion gp in items)
                goods.Add(gp.Good);
            return goods;
        }

        public List<Promotion> GetPromotions(Good g)
        {
            List<GoodPromotion> items = goodPromotionRepository.GetByGood(g).ToList<GoodPromotion>();
            List<Promotion> promotions = new List<Promotion>();
            foreach (GoodPromotion gp in items)
                promotions.Add(gp.Promotion);
            return promotions;
        }

        public List<GoodPromotion> GetGoodPromotionsByGood(Good g)
        {
            List<GoodPromotion> items = goodPromotionRepository.GetByGood(g).ToList<GoodPromotion>();
            return items;
        }

        async public Task aAddGoodPromotion(GoodPromotion goodPromotion)
        {
            await goodPromotionRepository.AddAsync(goodPromotion, new System.Threading.CancellationToken());
        }

        public GoodPromotion GetGoodPromotion(int goodId, int promotionId)
        {
            return goodPromotionRepository.Get(goodId, promotionId);
        }

        async public Task aRemoveGoodPromotion(Good good, Promotion promotion)
        {
            await goodPromotionRepository.RemoveAsync(GetGoodPromotion(good.Id, promotion.Id));
        }
    }
}
