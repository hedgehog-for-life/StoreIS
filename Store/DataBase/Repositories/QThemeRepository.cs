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
    class QThemeRepository : DbRepository<QTheme> , IEntityRepository<QTheme>
    {
        public QThemeRepository(stuff_shopContext db) : base(db) { }

        public QTheme Get(int id) => Items.SingleOrDefault(qTheme => qTheme.Id == id);
        public async Task<QTheme> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(qTheme => qTheme.Id == id, Cancel)
           .ConfigureAwait(false);

        public QTheme GetByName(string name) => Items.SingleOrDefault(qTheme => qTheme.ThemeName == name);

        public void Remove(int id)
        {
            var qTheme = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new QTheme { Id = id };
            _db.Remove(qTheme);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new QTheme { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
