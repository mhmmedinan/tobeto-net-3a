using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IModelRepository:IAsyncRepository<Model,int>
{
}
