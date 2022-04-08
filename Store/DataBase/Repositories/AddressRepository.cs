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
    class AddressRepository : DbRepository<Address>, IEntityRepository<Address>
    {
        public override IQueryable<Address> Items => base.Items
            .Include(item => item.Street)
            .Include(item => item.Street.City)
            .Include(item => item.Street.City.Region)
            .Include(item => item.Street.City.Region.Country)
            ;

        public AddressRepository(stuff_shopContext db) : base(db) { }

        public Address Get(int id) => Items.SingleOrDefault(address => address.Id == id);
        public async Task<Address> GetAsync(int id, CancellationToken Cancel = default) => await Items
           .SingleOrDefaultAsync(address => address.Id == id, Cancel)
           .ConfigureAwait(false);

        public void Remove(int id)
        {
            var address = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new Address { Id = id };
            _db.Remove(address);

            if (AutoSaveChanges)
                _db.SaveChanges();
        }
        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new Address { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public IQueryable<Address> GetActive() => Items.Where(address => address.AddType == 0);
        public IQueryable<Address> GetInactive() => Items.Where(address => address.AddType == 1);
        public IQueryable<Address> GetByCountryRegionCity(Country country, Region region, City city) => Items.Where(address =>
            address.Street.City == city && address.Street.City.Region == region && address.Street.City.Region.Country == country && address.AddType < 2);
        public Address GetByAll(Street street, string index, short type, string house, string appartment) => 
            Items.SingleOrDefault(address => address.Street == street && address.House == house 
            && address.AddIndex == index && address.AddType == type && address.ApartmentNum == appartment);
    }
}
