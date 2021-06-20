using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Api.DataAccess.IRepositories;
using ECommerce.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository) {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try {
                return Ok(await _productsRepository.GetAllAsync());
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpGet("GetAllByCategoryId/categoryId")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId) {
            try {
                return Ok(await _productsRepository
                    .GetByKeyAsync(e => e.ProductCategories
                        .Any(x => x.CategoryId == categoryId)));
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product, int categoryId) {
            try {
                if (categoryId == 0)
                    return BadRequest("Invalid Product category");

                product.ProductCategories = new List<ProductCategory> {
                    new() { CategoryId = categoryId }
                };

                return Ok(await _productsRepository.AddAsync(product));
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product) {
            try {
                await Task.Run(() => _productsRepository.Update(product));
                return Ok();
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId) {
            try {
                await _productsRepository.DeleteByIdAsync(productId);
                return Ok();
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
