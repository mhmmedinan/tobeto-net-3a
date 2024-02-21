using Business.Abstracts;
using Business.Requests.Models;
using Business.Responses.Models;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ModelManager : IModelService
{
    private readonly IModelRepository _modelRepository;

    public ModelManager(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
    {
        Model model = new Model();
        model.BrandId = request.BrandId;
        model.Name = request.Name;
        await _modelRepository.Add(model);

        CreateModelResponse response = new CreateModelResponse();
        response.BrandId = model.BrandId;
        response.Name = model.Name;
        response.CreatedDate = model.CreatedDate;
        return response;
    }

    public async Task<List<GetAllModelResponse>> GetAllAsync()
    {
        List<Model> models = await _modelRepository.GetAll(include:x=>x.Include(x=>x.Brand));
        List<GetAllModelResponse> responses = new List<GetAllModelResponse>();
        foreach (Model model in models)
        {
            GetAllModelResponse response = new GetAllModelResponse();
            response.Id= model.Id;
            response.BrandId = model.BrandId;
            response.Name = model.Name;
            response.BrandName = model.Brand.Name;
            responses.Add(response);
        }
        return responses;
    }
}
