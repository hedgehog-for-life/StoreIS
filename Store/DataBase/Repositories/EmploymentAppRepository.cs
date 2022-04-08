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
    class EmploymentAppRepository : DbRepository<EmploymentApp> , IEntityRepository<EmploymentApp>
    {
        public override IQueryable<EmploymentApp> Items => base.Items
            .Include(item => item.Applicant)
            .Include(item => item.Hr)
            ;

        public EmploymentAppRepository(stuff_shopContext db) : base(db) { }

        public EmploymentApp GetByUser(Person user) => Items.FirstOrDefault(emp => emp.Applicant == user);

        public IQueryable<EmploymentApp> GetWaiting() => Items.Where(emp => emp.AppStatus == 0);

        public IQueryable<EmploymentApp> GetForHR(Person hr) => Items.Where(emp => emp.Hr == hr);

        public EmploymentApp Get(int id) => Items.SingleOrDefault(employmentApp => employmentApp.Id == id);
        public async Task<EmploymentApp> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(employmentApp => employmentApp.Id == id, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var employmentApp = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new EmploymentApp { Id = id };
            _db.Remove(employmentApp);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new EmploymentApp { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
