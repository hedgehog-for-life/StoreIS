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
    class GoodRepository : DbRepository<Good> , IEntityRepository<Good>
    {
        public override IQueryable<Good> Items => base.Items.Include(item => item.Category);

        public GoodRepository(stuff_shopContext db) : base(db) { }

        public IQueryable<Good> GetAll()
        {
            return _db.Good;
        }

        public Good Get(int id) => Items.SingleOrDefault(good => good.Id == id);
        public async Task<Good> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(good => good.Id == id, Cancel)
           .ConfigureAwait(false);

        public Good GetByArticle(string article) => Items.SingleOrDefault(good => good.Article == article);
        public async Task<Good> GetByArticleAsync(string article, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(person => person.Article == article, Cancel)
           .ConfigureAwait(false);

        public IQueryable<Good> GetByCategory(Category category) => Items.Where(good => good.Category == category);

        public void Remove(int id)
        {
            var good = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Good { Id = id };
            _db.Remove(good);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Good { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public IQueryable<Good> GetLikeArticle(string article) => Items.Where(good => EF.Functions.Like(good.Article, "%" + article + "%"));
        public IQueryable<Good> GetLikeName(string name) => Items.Where(good => EF.Functions.Like(good.GoodName, "%" + name + "%"));
    }
}
