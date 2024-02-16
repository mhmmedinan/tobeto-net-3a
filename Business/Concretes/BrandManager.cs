using Business.Abstracts;
using Business.Requests.Brands;
using Business.Responses.Brands;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<CreateBrandResponse> AddAsync(CreateBrandRequest request)
    {
        Brand brand = new Brand();
        brand.Name=request.Name;
        await _brandRepository.Add(brand);

        CreateBrandResponse response = new CreateBrandResponse();
        response.Name = brand.Name;
        response.CreatedDate=brand.CreatedDate;
        return response;
    }

    public async Task<List<Brand>> GetAll()
    {
        return await _brandRepository.GetAll();
    }
}
