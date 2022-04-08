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
    class AddressController
    {
        private AddressRepository addressRepository;

        public AddressController(stuff_shopContext db)
        {
            addressRepository = new AddressRepository(db);
        }

        public List<Address> GetAllAddresses()
        {
            List<Address> addressesActive = addressRepository.GetActive().ToList<Address>();
            List<Address> addressesInactive = addressRepository.GetInactive().ToList<Address>();
            foreach(Address a in addressesInactive)
            {
                addressesActive.Add(a);
            }
            return addressesActive;
        }

        public Address GetByAll(Street street, string index, short type, string house, string appartment)
        {
            return addressRepository.GetByAll(street, index, type, house, appartment);
        }

        async public Task aAddAddress(Address address)
        {
            await addressRepository.AddAsync(address, new System.Threading.CancellationToken());
        }

        public void AddAddress(Address address)
        {
            addressRepository.Add(address);
        }

        public void RemoveAddress(int id)
        {
            addressRepository.Remove(id);
        }

        async public Task aUpdateAddress(Address address)
        {
            await addressRepository.UpdateAsync(address, new System.Threading.CancellationToken());
        }

        public void UpdateAddress(Address address)
        {
            addressRepository.Update(address);
        }

        public Address GetAddress(int id)
        {
            return addressRepository.Get(id);
        }

        public List<Address> FindByCountryAndRegionAndCity(Country country, Region region, City city)
        {
            return addressRepository.GetByCountryRegionCity(country, region, city).ToList();
        }

    }
}
