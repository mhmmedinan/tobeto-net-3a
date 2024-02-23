using Business.Abstracts;
using Business.Requests.Brands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBrandRequest request)
        {
            return HandleDataResult(await _brandService.AddAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _brandService.GetAllAsync());
        }
    }
}
