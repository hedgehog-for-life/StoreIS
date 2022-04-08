using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using Store.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class GoodController
    {
        private GoodRepository goodRepository;
        private StringValidator validator;
        private DateTimeValidator dtValidator;

        public GoodController(stuff_shopContext db)
        {
            goodRepository = new GoodRepository(db);
            validator = new StringValidator();
            dtValidator = new DateTimeValidator();
        }

        public List<Good> GetGoods()
        {
            List<Good> items = goodRepository.Items.ToList<Good>();
            return items;
        }

        public List<Good> GetAllGoods()
        {
            List<Good> items = goodRepository.GetAll().ToList<Good>();
            return items;
        }

        public List<Good> GetGoodsByCategory(Category category)
        {
            List<Good> items = goodRepository.GetByCategory(category).ToList<Good>();
            return items;
        }

        public Good GetGood(int id)
        {
            return goodRepository.Get(id);
        }

        public Good GetGoodByArticle(string article)
        {
            return goodRepository.GetByArticle(article);
        }

        async public Task UpdateGoodAsync(Good good)
        {
                await goodRepository.UpdateAsync(good, new System.Threading.CancellationToken());
        }

        async public Task AddGoodAsync(Good good)
        {
                await goodRepository.AddAsync(good, new System.Threading.CancellationToken());
        }

        public void UpdateGood(Good good)
        {
            goodRepository.Update(good);
        }

        public void AddGood(Good good)
        {
            goodRepository.Add(good);
        }

        async public Task DeleteGoodAsync(int id)
        {
            await goodRepository.RemoveAsync(id);
        }

        public void DeleteGood(int id)
        {
            goodRepository.Remove(id);
        }

        public List<Good> SearchByArticle(string articleLike)
        {
            return goodRepository.GetLikeArticle(articleLike).ToList();
        }

        public List<Good> SearchByName(string nameLike)
        {
            return goodRepository.GetLikeName(nameLike).ToList();
        }
    }
}
