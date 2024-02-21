using Business.Abstracts;
using Business.Requests.Models;
using Business.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
        {
            return await _modelService.AddAsync(request);
        }

        [HttpGet]
        public async Task<List<GetAllModelResponse>> GetAllAsync()
        {
            return await _modelService.GetAllAsync();
        }
    }
}
