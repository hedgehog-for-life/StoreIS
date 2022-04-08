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
    class PersonRepository : DbRepository<Person>, IEntityRepository<Person>
    {
        public override IQueryable<Person> Items => base.Items.Include(item => item.Role);

        public PersonRepository(stuff_shopContext db) : base(db) { }

        public Person Get(int id)
        {
            Person result = Items.SingleOrDefault(person => person.Id == id);
            if (result != null) _db.Entry(result).State = EntityState.Detached;
            return result;
        }


        public async Task<Person> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(person => person.Id == id, Cancel)
           .ConfigureAwait(false);

        public Person GetByEmail(string email) {
           Person result =  Items.SingleOrDefault(user => user.Email == email);

            if(result != null) _db.Entry(result).State = EntityState.Detached;

            return result;
            }
        public async Task<Person> GetByEmailAsync(string email, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(person => person.Email == email, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var person = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Person { Id = id };
            _db.Remove(person);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Person { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
