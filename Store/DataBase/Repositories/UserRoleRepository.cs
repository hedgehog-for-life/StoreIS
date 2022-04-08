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
    class UserRoleRepository : DbRepository<UserRole> , IEntityRepository<UserRole>
    {
        public UserRoleRepository(stuff_shopContext db) : base(db) { }

        public UserRole Get(int id) => Items.SingleOrDefault(userRole => userRole.Id == id);
        public async Task<UserRole> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(userRole => userRole.Id == id, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var userRole = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new UserRole { Id = id };
            _db.Remove(userRole);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new UserRole { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
