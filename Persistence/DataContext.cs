using Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DataContext
    {
        public static async Task<List<Product>> GetProducts()
        {
            string filePath = Directory.GetParent(DataContext.ToApplicationPath()).FullName + "\\Persistence\\Products.json";
            List<Product> products = await Task.FromResult<List<Product>>(JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(filePath)));
            List<Product> productList = products;
            return productList;
        }

        public static async Task<List<Promotion>> GetAvailablePromotions()
        {
            string filePath = Directory.GetParent(DataContext.ToApplicationPath()).FullName + "\\Persistence\\PromotionPrice.json";
            List<Promotion> promotion = await Task.FromResult<List<Promotion>>(JsonConvert.DeserializeObject<List<Promotion>>(File.ReadAllText(filePath)));
            List<Promotion> promotionList = promotion;
            return promotionList;
        }

        public static string ToApplicationPath() => new Regex("(?<!fil)[A-Za-z]:\\\\+[\\S\\s]*?(?=\\\\+bin)")
            .Match(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).Value;
    }
}
