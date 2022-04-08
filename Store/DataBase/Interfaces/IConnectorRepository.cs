using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Interfaces
{
    public interface IConnectorRepository<T>
    {
        T Get(int key1, int key2);
        Task<T> GetAsync(int key1, int key2, CancellationToken Cancel = default);

        void Remove(int key1, int key2);
        Task RemoveAsync(int key1, int key2, CancellationToken Cancel = default);
    }
}
