using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBrandRepository:IAsyncRepository<Brand,int>
{

}
