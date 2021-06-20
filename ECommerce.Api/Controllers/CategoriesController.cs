using System;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository) {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            try {
                return Ok(await _categoriesRepository.GetAllAsync());
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category) {
            try {
                return Ok(await _categoriesRepository.AddAsync(category));
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category) {
            try {
                await Task.Run(() => _categoriesRepository.Update(category));
                return Ok();
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int categoryId) {
            try {
                await _categoriesRepository.DeleteByIdAsync(categoryId);
                return Ok();
            } catch (Exception e) {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
