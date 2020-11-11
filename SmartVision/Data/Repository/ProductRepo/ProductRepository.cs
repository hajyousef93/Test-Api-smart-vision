using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartVision.Model;
using SmartVision.ModelViews.products;

namespace SmartVision.Data.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
           _db=db;
        }
        public async Task<Product> AddProduct(AddProductModel model)
        {
            if (model == null)
            {
                return null;
            }
            var product = new Product
            {
                Name=model.Name,
                Price=model.Price

            };
             await _db.Products.AddAsync(product);

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                _db.Products.Remove(product);

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
           
            
        }

        public async Task<Product> EditProduct(EditProductModel model)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (product == null)
            {
                return null;
            }
            product.Name = model.Name;
            product.Price = model.Price;
            _db.Products.Attach(product);
            _db.Entry(product).Property(x => x.Name).IsModified = true;
            _db.Entry(product).Property(x => x.Price).IsModified = true;
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {

            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
