using AutoMapper;
using Business.Abstracts;
using Business.Requests.Brands;
using Business.Responses.Brands;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public BrandManager(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
    {
        Brand brand = _mapper.Map<Brand>(request);
        await _brandRepository.Add(brand);

        CreateBrandResponse response = _mapper.Map<CreateBrandResponse>(brand);
        return response;
    }

    public async Task<List<GetAllBrandResponse>> GetAllAsync()
    {
        List<Brand> brands = await _brandRepository.GetAll();
        List<GetAllBrandResponse> responses = _mapper.Map<List<GetAllBrandResponse>>(brands);
        return responses;
    }
}
