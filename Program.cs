using MMTTestApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MMTTestConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var categories = await GetAllCategories();

            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"Id - {categories[i].Id}, Name - {categories[i].Name} ");
            }

            Console.WriteLine("Please copy and paste the category id");
            var categoryId = Console.ReadLine();
            var products = await GetProductsByCategoryId(new Guid(categoryId));

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($" Name - {products[i].Name} ");
            }
        }

        static async Task<IList<Category>> GetAllCategories()
        {
            var categories = new List<Category>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("Category/GetAllCategories/");

                var resultString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    categories = JsonConvert.DeserializeObject<List<Category>>(resultString);
                }
                else
                {
                    Console.WriteLine(resultString);
                }
            }

            return categories;
        }

        static async Task<IList<Product>> GetProductsByCategoryId(Guid categoryId)
        {
            var products = new List<Product>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"Product/GetProductsByCategoryId/{categoryId}");

                var resultString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    products = JsonConvert.DeserializeObject<List<Product>>(resultString);
                }
                else
                {
                    Console.WriteLine(resultString);
                }
            }

            return products;
        }
    }
}
