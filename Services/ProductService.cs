using MMTTestApi.Interfaces;
using MMTTestApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTTestApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts();

            return result;
        }

        public async Task<ICollection<Product>> GetProductsByCategoryId(Guid categoryId)
        {
            var categoryExists = await _categoryRepository.Exists(categoryId);
            if (!categoryExists)
                throw new KeyNotFoundException($"CategoryId - {categoryId} does not exists");

            var result = await _productRepository.GetProductsByCategoryId(categoryId);
            if (result == null || result.Count == 0)
                throw new Exception($"No products found for Category Id - {categoryId}");

            return result;
        }
    }
}
