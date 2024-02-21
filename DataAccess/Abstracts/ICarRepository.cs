using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ICarRepository:IAsyncRepository<Car,int>
{
}
