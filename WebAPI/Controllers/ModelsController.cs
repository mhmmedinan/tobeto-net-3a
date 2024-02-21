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
        public Task<CreateModelResponse> AddAsync(CreateModelRequest request)
        {
            return _modelService.AddAsync(request);
        }

        [HttpGet]
        public Task<List<GetAllModelResponse>> GetAllAsync()
        {
            return _modelService.GetAllAsync();
        }
    }
}
