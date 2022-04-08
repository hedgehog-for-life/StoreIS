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
    class PromotionController
    {
        private PromotionRepository promotionRepository;

        public PromotionController(stuff_shopContext db)
        {
            promotionRepository = new PromotionRepository(db);
        }

        public List<Promotion> GetPromotions()
        {
            List<Promotion> items = promotionRepository.Items.ToList<Promotion>();
            return items;
        } 

        public void AddPromotion(Promotion promotion)
        {
            promotionRepository.Add(promotion);
        }

        async public Task aUpdatePromotion(Promotion promotion)
        {
            await promotionRepository.UpdateAsync(promotion, new System.Threading.CancellationToken());
        }

        public void RemovePromotion(int id)
        {
            promotionRepository.Remove(id);
        }

        public List<Promotion> GetCurrentPromotions()
        {
            return promotionRepository.GetCurrent().ToList();
        }

        public Promotion GetPromotion(int id)
        {
            return promotionRepository.Get(id);
        }
    }
}
