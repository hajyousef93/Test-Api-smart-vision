using SmartVision.Model;
using SmartVision.ModelViews.products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVision.Data.Repository.ProductRepo
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(AddProductModel model);
        Task<Product> GetProduct(int id);
        Task<Product> EditProduct(EditProductModel model);
        Task<bool> DeleteProduct(int id);

    }
}
