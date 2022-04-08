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
    class CategoryController
    {
        private CategoryRepository categoryRepository;

        public CategoryController(stuff_shopContext db)
        {
            categoryRepository = new CategoryRepository(db);
        }

        public List<Category> GetCategories()
        {
            List<Category> items = categoryRepository.Items.ToList<Category>();
            return items;
        }

        public Category GetCategoryByName(string name)
        {
            return categoryRepository.GetByName(name);
        }

        public Category GetCategory(int id)
        {
            return categoryRepository.Get(id);
        }

        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        async public Task aUpdateCategory(Category category)
        {
            await categoryRepository.UpdateAsync(category, new System.Threading.CancellationToken());
        }

        async public Task aRemoveCategory(Category category)
        {
            await categoryRepository.RemoveAsync(category, new System.Threading.CancellationToken());
        }

        public List<Category> GetCategoriesLikeName(string name)
        {
            return categoryRepository.GetLikeName(name).ToList();
        }
    }
}
