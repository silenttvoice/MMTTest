using MMTTestApi.Interfaces;
using MMTTestApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTTestApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ICollection<Category>> GetAllCategories()
        {
            var results = await _categoryRepository.GetAllCategories();
            if (results == null || results.Count == 0)
                throw new Exception("No categories found");

            return results;
        }
    }
}
