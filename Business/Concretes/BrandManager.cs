using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.Extensions.Logging;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _rules;

    public BrandManager(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules rules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _rules = rules;
    }


    //[LogAspect(typeof(MssqlLogger))]
    public async Task<IDataResult<CreateBrandResponse>> AddAsync(CreateBrandRequest request)
    {
        await _rules.CheckIfBrandNameNotExists(request.Name.TrimStart());
        Brand brand = _mapper.Map<Brand>(request);
        brand.Id = Guid.NewGuid();
        await _brandRepository.Add(brand);

        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);
        return new SuccessDataResult<CreateBrandResponse>(response, BrandMessages.BrandAdded);

    }

    public async Task<IResult> Delete(DeleteBrandRequest deleteBrandRequest)
    {
        Brand brand = _mapper.Map<Brand>(deleteBrandRequest);
        await _brandRepository.Delete(brand);
        return new SuccessResult("Silindi");

    }

    [LogAspect(typeof(MongoDbLogger))]
    public async Task<IDataResult<List<GetAllBrandResponse>>> GetAllAsync()
    {
        List<Brand> brands = await _brandRepository.GetAll();
        List<GetAllBrandResponse> responses = _mapper.Map<List<GetAllBrandResponse>>(brands);
        return new SuccessDataResult<List<GetAllBrandResponse>>(responses, "Listed Successfully");
    }

    public async Task<List<GetAllBrandResponse>> GetAllBrandName(string name)
    {
        List<Brand> brands = await _brandRepository.GetAll(x=>x.Name==name);
        List<GetAllBrandResponse> responses = _mapper.Map<List<GetAllBrandResponse>>(brands);
        return responses;
    }

    public async Task<Brand> GetById(Guid id)
    {
        Brand brand = await _brandRepository.Get(x=>x.Id==id);
        return brand;
    }
}
