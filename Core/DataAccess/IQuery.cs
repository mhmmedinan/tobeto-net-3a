namespace Core.DataAccess;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
