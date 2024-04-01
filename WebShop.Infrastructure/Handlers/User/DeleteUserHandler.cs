using AutoMapper;
using MediatR;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Requests.User;

namespace WebShop.Infrastructure.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IRepository<UserEntity> _repository;

    public DeleteUserHandler(IRepository<UserEntity> repository, IMapper mapper)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id, false, cancellationToken);

        await _repository.DeleteEntity(user, cancellationToken);
        
        return true;
    }
}