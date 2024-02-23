using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Abstracts;

public interface ICarService
{
    Task<CreateCarResponse> AddAsync(CreateCarRequest request);
    Task<List<GetAllCarResponse>> GetAllAsync();
     
}
