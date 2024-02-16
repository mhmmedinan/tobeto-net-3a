using Business.Requests.Brands;
using Business.Responses.Brands;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IBrandService
{
    Task<CreateBrandResponse> AddAsync(CreateBrandRequest request);
    Task<List<Brand>> GetAll();
}
