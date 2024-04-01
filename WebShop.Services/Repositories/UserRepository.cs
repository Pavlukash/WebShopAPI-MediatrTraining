using Microsoft.EntityFrameworkCore;
using WebShop.DataAccess.Extensions;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Contexts;
using WebShop.Domain.Entities.User;

namespace WebShop.DataAccess.Repositories;

public sealed class UserRepository : IRepository<UserEntity>
{
    private readonly WebShopContext _webShopContext;

    public UserRepository(WebShopContext webShopContext)
    {
        _webShopContext = webShopContext;
    }

    public IQueryable<UserEntity> QueryAll(bool track)
    {
        var users = _webShopContext.Users
            .TrackIf(track);

        return users;
    }

    public async Task<UserEntity> GetById(int id, bool allowNull, CancellationToken cancellationToken)
    {
        var user = await _webShopContext.Users
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstAllowNullAsync(allowNull, cancellationToken);

        return user;
    }

    public async Task AddEntity(UserEntity entity, CancellationToken cancellationToken)
    {
        _webShopContext.Users.Add(entity);
        await _webShopContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEntity(UserEntity entity, CancellationToken cancellationToken)
    {
        _webShopContext.Users.Remove(entity);
        await _webShopContext.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _webShopContext.SaveChangesAsync(cancellationToken);
}