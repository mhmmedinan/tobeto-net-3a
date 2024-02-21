using Business.Requests.Models;
using Business.Responses.Models;

namespace Business.Abstracts;

public interface IModelService
{
    Task<CreateModelResponse> AddAsync(CreateModelRequest request);
    Task<List<GetAllModelResponse>> GetAllAsync();
}
