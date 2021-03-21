using MMTTestApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTTestApi.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetAllCategories();

        Task<bool> Exists(Guid categoryId);
    }
}
