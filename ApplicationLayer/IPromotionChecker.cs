using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IPromotionChecker
    {
        public Task<List<Product>> GetProducts();
        public Task<DiscountDto> GetTotalPrice(Order ord);
    }
}