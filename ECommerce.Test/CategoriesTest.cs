using System.Collections.Generic;
using ECommerce.Api.Controllers;
using ECommerce.Api.DataAccess.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Category = ECommerce.Model.Category;

namespace ECommerce.Test
{
    public class CategoriesTest
    {
        public Mock<ICategoriesRepository> CategoriesRepositoryMock = new();
        public CategoriesController CategoriesController;

        public CategoriesTest() {
            CategoriesController = new CategoriesController(CategoriesRepositoryMock.Object);
        }

        [Fact]
        public async void GetAllAsync_ShouldReturnAllItems() {
            var categories = new List<Category>
            {
                new() {EnName = "Category 1", ArName = "Category 1"},
                new () {EnName = "Category 2", ArName = "Category 2"}
            };

            // Test repository
            CategoriesRepositoryMock.Setup(e => e.GetAllAsync())
                .ReturnsAsync(categories);

            var categoriesList = await CategoriesRepositoryMock.Object.GetAllAsync();
            Assert.NotNull(categoriesList);

            // Test Controller
            var result = await CategoriesController.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void AddCategoryTest() {
            var category = new Category() {
                Id = 1,
                EnName = "Category 1",
                ArName = "ÇáÊÕäíÝ 1"
            };

            // Test repository
            CategoriesRepositoryMock.Setup(e => e.AddAsync(category))
                .ReturnsAsync(category);

            var item = await CategoriesRepositoryMock.Object.AddAsync(category);
            Assert.NotNull(item);
            Assert.Equal(item.Id, category.Id);

            // Test Controller
            var result = await CategoriesController.Add(category);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
