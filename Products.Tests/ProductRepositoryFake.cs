using Products.Data;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Tests
{
    public class ProductRepositoryFake : IProductRepository
    {
        private readonly List<Product> _context;
        public ProductRepositoryFake()
        {
            _context = new List<Product>()
            {
                new Product() {Id = 1, Name = "Guitarra", AgeRestriction = 25, Company = "Hasbro", Description="Just a guitarr", Price = 300},
                new Product() {Id = 2, Name = "Remoto", AgeRestriction = 10, Company = "Samnsung", Description="Just a remote", Price = 30},
                new Product() {Id = 3, Name = "Cartera", AgeRestriction = 7, Company = "Perry Ellis", Description="Just a wallet", Price = 30}
            };

        }
        public void CreateProduct(Product product)
        {
            _context.Add(product);
        }

        public void DeleteProduct(int Id)
        {
            var productFromRepo = _context.Find(x => x.Id == Id);
            _context.Remove(productFromRepo);
        }

        public Task<Product> EditProduct(int Id, Product product)
        {
            var index = _context.FindIndex(x => x.Id == Id);

            _context[index].Name = product.Name;
            _context[index].AgeRestriction = product.AgeRestriction;
            _context[index].Company = product.Company;
            _context[index].Description = product.Description;
            _context[index].Price = product.Price;

            var productFromRepo = _context.Find(x => x.Id == Id);

            return Task.FromResult(productFromRepo);


        }

        public Task<Product> GetProduct(int Id)
        {
            var product = _context.Find(x => x.Id == Id);
            return Task.FromResult(product);
        }

        public Task<List<Product>> GetProducts()
        {
            var products = _context;
            return Task.FromResult(products);
        }

        public Task<bool> SaveAll()
        {
            bool saveAll = true;
            return Task.FromResult(saveAll);
        }
    }
}
