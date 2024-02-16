using Business.Abstracts;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
        {
          return await _brandService.AddAsync(request);
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _brandService.GetAll());
        }
    }
}
