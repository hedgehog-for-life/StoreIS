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
    class WriteOffRepository : DbRepository<WriteOff> , IEntityRepository<WriteOff>
    {
        public override IQueryable<WriteOff> Items => base.Items
            .Include(item => item.Good)
            .Include(item => item.Reason)
            ;

        public WriteOffRepository(stuff_shopContext db) : base(db) { }

        public WriteOff Get(int id) => Items.SingleOrDefault(writeOff => writeOff.Id == id);
        public async Task<WriteOff> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(writeOff => writeOff.Id == id, Cancel)
           .ConfigureAwait(false);

        public IQueryable<WriteOff> GetByReason(WriteOffReason reason) => Items.Where(writeOff => writeOff.Reason == reason);

        public void Remove(int id)
        {
            var writeOff = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new WriteOff { Id = id };
            _db.Remove(writeOff);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new WriteOff { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public async Task RemoveAsync(WriteOff writeOff, CancellationToken Cancel = default)
        {
            _db.Remove(writeOff);
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
