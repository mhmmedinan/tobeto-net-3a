using Business.Requests.Cars;
using Business.Responses.Cars;

namespace Business.Abstracts;

public interface ICarService
{
    Task<CreateCarResponse> AddAsync(CreateCarRequest request);
    Task<List<GetAllCarResponse>> GetAllAsync();
}
