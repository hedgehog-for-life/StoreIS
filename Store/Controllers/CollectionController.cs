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
    class CollectionController
    {
        private CollectionRepository collectionRepository;

        public CollectionController(stuff_shopContext db)
        {
            collectionRepository = new CollectionRepository(db);
        }

        public List<Collection> GetAllCollections()
        {
            List<Collection> items = collectionRepository.Items.ToList<Collection>();
            return items;
        }

        public Collection GetCollectionByName(string name)
        {
            return collectionRepository.GetByName(name);
        }

        public void AddCollection(Collection collection)
        {
            collectionRepository.Add(collection);
        }

        async public Task UpdateCollectionAsync(Collection collection)
        {
            await collectionRepository.UpdateAsync(collection, new System.Threading.CancellationToken());
        }

        async public Task RemoveCollectionAsync(int id)
        {
            await collectionRepository.RemoveAsync(id, new System.Threading.CancellationToken());
        }

        public void RemoveCollection(int id)
        {
            collectionRepository.Remove(id);
        }

        public List<Collection> GetActiveCollections()
        {
            return collectionRepository.GetActive().ToList();
        }

        public Collection GetCollectiom(int id)
        {
            return collectionRepository.Get(id);
        }

        public List<Collection> GetCollectionsLikeName(string name)
        {
            return collectionRepository.GetLikeName(name).ToList();
        }
    }
}
