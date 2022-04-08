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
    class CategoryRepository : DbRepository<Category> , IEntityRepository<Category>
    {
        public CategoryRepository(stuff_shopContext db) : base(db) { }

        public Category Get(int id) => Items.SingleOrDefault(category => category.Id == id);
        public async Task<Category> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(category => category.Id == id, Cancel)
           .ConfigureAwait(false);

        public Category GetByName(string name) => Items.SingleOrDefault(category => category.CName == name);
        public async Task<Category> GetByNameAsync(string name, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(category => category.CName == name, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var category = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Category { Id = id };
            _db.Remove(category);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Category { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public async Task RemoveAsync(Category category, CancellationToken Cancel = default)
        {
            _db.Remove(category);
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public IQueryable<Category> GetLikeName(string name) => Items.Where(category => EF.Functions.Like(category.CName, "%" + name + "%"));
    }
}
