using MMTTestApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTTestApi.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProducts();
        Task<ICollection<Product>> GetProductsByCategoryId(Guid categoryId);
    }
}
