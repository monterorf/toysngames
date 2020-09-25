using Microsoft.AspNetCore.Mvc;
using Products.Controllers;
using Products.Data;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Products.Tests
{
    public class ProductsControllerTest
    {
        ProductsController _controller;
        IProductRepository _repo;
        public ProductsControllerTest()
        {
            _repo = new ProductRepositoryFake();
            _controller = new ProductsController(_repo);
        }

        [Fact]
        public void Get_All_Products_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetProducts();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_A_Product_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetProduct(1);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Create_A_Product_WhenCalled_ReturnsOkResult()
        {
            var product = new Product() { Id = 1, Name = "Guitarra", AgeRestriction = 25, Company = "Hasbro", Description = "Just a guitarr", Price = 300 };
            var okResult = _controller.CreateProduct(product);

            Assert.IsType<OkResult>(okResult.Result);
        }

        [Fact]
        public void Update_A_Product_WhenCalled_ReturnsOkResult()
        {
            var product = new Product() { Id = 1, Name = "GuitarraActualizada", AgeRestriction = 25, Company = "Hasbro", Description = "Just a guitarr", Price = 300 };
            var okResult = _controller.EditProduct(1, product);

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Delete_A_Product_WhenCalled_ReturnsOkResult()
        {            
            var okResult = _controller.DeleteProduct(1);

            Assert.IsType<OkResult>(okResult.Result);
        }

    }
}
