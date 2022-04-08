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
    class WriteOffReasonController
    {
        private WriteOffReasonRepository writeOffReasonRepository;

        public WriteOffReasonController(stuff_shopContext db)
        {
            writeOffReasonRepository = new WriteOffReasonRepository(db);
        }

        public List<WriteOffReason> GetWriteOffReasons()
        {
            List<WriteOffReason> items = writeOffReasonRepository.Items.ToList();
            return items;
        }

        public WriteOffReason GetReason(int id)
        {
            return writeOffReasonRepository.Get(id);
        }

        public WriteOffReason GetReasonByName(string name)
        {
            return writeOffReasonRepository.GetByName(name);
        }

        async public Task aUpdateReason(WriteOffReason reason)
        {
            await writeOffReasonRepository.UpdateAsync(reason, new System.Threading.CancellationToken());
        }

        public void UpdateReason(WriteOffReason reason)
        {
            writeOffReasonRepository.Update(reason);
        }

        public bool AddReason(WriteOffReason reason)
        {
            if (writeOffReasonRepository.GetByName(reason.ReasonName) == null) 
            {
                writeOffReasonRepository.Add(reason);
                return true;
            }
            return false;
        }

        async public Task aDeleteReason(WriteOffReason reason)
        {
            await writeOffReasonRepository.RemoveAsync(reason, new System.Threading.CancellationToken());
        }
    }
}
