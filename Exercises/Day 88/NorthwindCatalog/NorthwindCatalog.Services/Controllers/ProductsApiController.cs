using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Repositories;

namespace NorthwindCatalog.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _repo.GetByCategoryIdAsync(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var data = await _repo.GetCategorySummariesAsync();
            return Ok(data);
        }
    }
}
