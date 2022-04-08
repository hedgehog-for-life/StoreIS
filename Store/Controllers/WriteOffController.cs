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
    class WriteOffController
    {
        private WriteOffRepository writeOffRepositoty;

        public WriteOffController(stuff_shopContext db)
        {
            writeOffRepositoty = new WriteOffRepository(db);
        }

        public List<WriteOff> GetWriteOffs()
        {
            List<WriteOff> items = writeOffRepositoty.Items.ToList();
            return items;
        }

        public WriteOff GetWriteOff(int id)
        {
            return writeOffRepositoty.Get(id);
        }

        async public Task aUpdateWriteOff(WriteOff writeOff)
        {
            await writeOffRepositoty.UpdateAsync(writeOff, new System.Threading.CancellationToken());
        }

        public void UpdateWriteOff(WriteOff writeOff)
        {
            writeOffRepositoty.Update(writeOff);
        }

        async public Task aAddWriteOff(WriteOff writeOff)
        {
            await writeOffRepositoty.AddAsync(writeOff, new System.Threading.CancellationToken());
        }

        public void AddWriteOff(WriteOff writeOff)
        {
            writeOffRepositoty.Add(writeOff);
        }

        async public Task aDeleteWriteOff(int id)
        {
            await writeOffRepositoty.RemoveAsync(writeOffRepositoty.Get(id), new System.Threading.CancellationToken());
        }

        public List<WriteOff> GetByReason(WriteOffReason reason)
        {
            return writeOffRepositoty.GetByReason(reason).ToList();
        }
    }
}
