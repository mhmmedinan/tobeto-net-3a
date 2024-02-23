using Business.Abstracts;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Core.Utilities.Results;
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
        public async Task<IActionResult> AddAsync(CreateBrandRequest request)
        {
            var result = await _brandService.AddAsync(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

          
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IDataResult<List<GetAllBrandResponse>> result = await _brandService.GetAllAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
