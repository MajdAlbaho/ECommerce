using System.Collections.Generic;
using System.Linq;
using ECommerce.Api.Controllers;
using ECommerce.Api.DataAccess.IRepositories;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ECommerce.Test
{
    public class ProductTest
    {
        public Mock<IProductsRepository> ProductsRepositoryMock = new();
        public ProductsController ProductsController;

        public ProductTest() {
            ProductsController = new ProductsController(ProductsRepositoryMock.Object);
        }

        [Fact]
        public async void GetAllAsync_ShouldReturnAllItems() {
            var categories = new List<Product>
            {
                new() {EnName = "Product 1", ArName = "Product 1"},
                new () {EnName = "Product 2", ArName = "Product 2"}
            };

            // Test repository
            ProductsRepositoryMock.Setup(e => e.GetAllAsync())
                .ReturnsAsync(categories);

            var categoriesList = await ProductsRepositoryMock.Object.GetAllAsync();
            Assert.NotNull(categoriesList);

            // Test Controller
            var result = await ProductsController.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetProductsByCategoryId_ShouldReturnAllProductsIfExist() {
            int categoryId = 1;

            // Test repository
            ProductsRepositoryMock.Setup(e => e.GetByKeyAsync(x =>
                    x.ProductCategories
                    .Any(c => c.CategoryId == categoryId)))
                .ReturnsAsync(new List<Product>
                {
                    new (){ EnName = "Product 1", ArName = "Product 1", Id = 1 },
                    new (){ EnName = "Product 2", ArName = "Product 2", Id = 2 },
                });

            var categoriesList = await ProductsRepositoryMock.Object.GetByKeyAsync(x =>
                    x.ProductCategories
                        .Any(c => c.CategoryId == categoryId
                ));
            Assert.NotNull(categoriesList);

            // Test Controller
            var result = await ProductsController.GetAllByCategoryId(categoryId);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddCategoryTest() {
            var product = new Product {
                Id = 1,
                EnName = "Product 1",
                ArName = "المنتج 1"
            };

            // Test repository
            ProductsRepositoryMock.Setup(e => e.AddAsync(product))
                .ReturnsAsync(product);

            var item = await ProductsRepositoryMock.Object.AddAsync(product);
            Assert.NotNull(item);
            Assert.Equal(item.Id, product.Id);

            // Test Controller
            var result = await ProductsController.Add(product, 2);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
