using Dapper;
using Microsoft.Extensions.Configuration;
using MMTTestApi.Interfaces;
using MMTTestApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTestApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ICollection<Category>> GetAllCategories()
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await conn.OpenAsync();

                var result = await conn.QueryAsync<Category>("[dbo].[spGetAllCategories]", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<bool> Exists(Guid categoryId)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await conn.OpenAsync();

                var p = new DynamicParameters();
                p.Add("@CategoryId", categoryId);

                var result = await conn.QueryAsync<bool>("[dbo].[spCategoryIdExists]", p, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }
    }
}
