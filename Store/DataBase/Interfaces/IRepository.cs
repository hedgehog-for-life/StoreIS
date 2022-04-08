using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Interfaces
{
    public interface IRepository<T>
    {
        // Доступ ко всему внутри репозитория
        IQueryable<T> Items { get; }

        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken Cancel = default);

        void Update(T item);
        Task UpdateAsync(T item, CancellationToken Cancel = default);
    }
}
