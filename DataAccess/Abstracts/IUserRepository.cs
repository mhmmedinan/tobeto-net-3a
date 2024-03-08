using Core.DataAccess;
using Core.Utilities.Security.Entities;

namespace DataAccess.Abstracts;

public interface IUserRepository:IAsyncRepository<User,Guid>
{
}
