using Microsoft.EntityFrameworkCore;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.DataBase.Repositories
{
    class CodeRepository : DbRepository<Code> , IEntityRepository<Code>
    {
        public CodeRepository(stuff_shopContext db) : base(db) { }

        public override IQueryable<Code> Items => base.Items.Include(item => item.Role);

        public Code Get(int id) => Items.SingleOrDefault(code => code.Id == id);
        public async Task<Code> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(code => code.Id == id, Cancel)
           .ConfigureAwait(false);

        public Code GetByRole(UserRole role) => Items.SingleOrDefault(code => code.Role == role);
        public async Task<Code> GetByRoleAsync(UserRole role, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(code => code.Role == role, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var code = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Code { Id = id };
            _db.Remove(code);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Code { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
