using Business.Requests.Brands;
using Business.Responses.Brands;
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IBrandService
{
    Task<IDataResult<CreateBrandResponse>> AddAsync(CreateBrandRequest request);
    Task<IDataResult<List<GetAllBrandResponse>>> GetAllAsync();
    Task<IResult> Delete(DeleteBrandRequest deleteBrandRequest);
}
