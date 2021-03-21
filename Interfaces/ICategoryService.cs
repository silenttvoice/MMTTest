using MMTTestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTTestApi.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllCategories();
    }
}
