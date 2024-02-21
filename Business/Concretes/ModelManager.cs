using AutoMapper;
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
    private readonly IMapper _mapper;

    public ModelManager(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<CreateModelResponse> AddAsync(CreateModelRequest request)
    {
        Model model = _mapper.Map<Model>(request);
        await _modelRepository.Add(model);

        CreateModelResponse response = _mapper.Map<CreateModelResponse>(model);
        return response;
    }

    public async Task<List<GetAllModelResponse>> GetAllAsync()
    {
        List<Model> models = await _modelRepository.GetAll(include:x=>x.Include(x=>x.Brand));
        List<GetAllModelResponse> responses = _mapper.Map<List<GetAllModelResponse>>(models);
        return responses;
    }
}
