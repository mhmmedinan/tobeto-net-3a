using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.Repositories;

public class CarRepository : EfRepositoryBase<Car, int, BaseDbContext>,ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}
