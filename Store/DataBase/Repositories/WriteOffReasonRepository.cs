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
    class WriteOffReasonRepository : DbRepository<WriteOffReason> , IEntityRepository<WriteOffReason>
    {
        public WriteOffReasonRepository(stuff_shopContext db) : base(db) { }

        public WriteOffReason Get(int id) => Items.SingleOrDefault(writeOffReason => writeOffReason.Id == id);
        public async Task<WriteOffReason> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(writeOffReason => writeOffReason.Id == id, Cancel)
           .ConfigureAwait(false);

        public WriteOffReason GetByName(string name) => Items.SingleOrDefault(writeOffReason => writeOffReason.ReasonName == name);
        public async Task<WriteOffReason> GetByNameAsync(string name, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(writeOffReason => writeOffReason.ReasonName == name, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var writeOffReason = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new WriteOffReason { Id = id };
            _db.Remove(writeOffReason);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new WriteOffReason { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
        public async Task RemoveAsync(WriteOffReason reason, CancellationToken Cancel = default)
        {
            _db.Remove(reason);
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
