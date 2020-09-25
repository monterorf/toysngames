using Microsoft.EntityFrameworkCore;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;

        }
        public void CreateProduct(Product product)
        {
            _context.Add(product);
        }

        public async void DeleteProduct(int Id)
        {
            var productFromRepo = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Remove(productFromRepo);
        }


        public async Task<Product> EditProduct(int Id, Product product)
        {
            var productFromRepo = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (productFromRepo != null)
                productFromRepo.Name = product.Name;
            productFromRepo.Description = product.Description;
            productFromRepo.Price = product.Price;
            productFromRepo.Company = product.Company;


            await SaveAll();

            return productFromRepo;

        }

        public async Task<Product> GetProduct(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
