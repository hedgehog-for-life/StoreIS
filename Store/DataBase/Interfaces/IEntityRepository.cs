using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Interfaces
{
    public interface IEntityRepository<T>
    {
        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken Cancel = default);

        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken Cancel = default);
    }
}
