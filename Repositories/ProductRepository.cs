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
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await conn.OpenAsync();

                var result = await conn.QueryAsync<Product>("[dbo].[spGetAllProducts]", commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

        public async Task<ICollection<Product>> GetProductsByCategoryId(Guid categoryId)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await conn.OpenAsync();

                var p = new DynamicParameters();
                p.Add("@CategoryId", categoryId);

                var result = await conn.QueryAsync<Product>("[dbo].[spGetProductsByCategoryId]", p, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }
    }
}
