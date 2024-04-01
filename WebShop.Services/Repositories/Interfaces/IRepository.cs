namespace WebShop.DataAccess.Repositories.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> QueryAll(bool track);
    Task<T> GetById(int id, bool allowNull, CancellationToken cancellationToken);
    Task AddEntity(T entity, CancellationToken cancellationToken);
    Task DeleteEntity(T entity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}