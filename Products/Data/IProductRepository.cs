using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Data
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int Id);
        Task<Product> EditProduct(int Id, Product product);
        void DeleteProduct(int Id);
        Task<bool> SaveAll();
    }
}
