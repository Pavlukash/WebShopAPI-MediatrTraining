using AutoMapper;
using MediatR;
using WebShop.DataAccess.Exceptions;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Requests.User;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Handlers.User;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IRepository<UserEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUserEntity = _mapper.Map<UserEntity>(request);
        if (newUserEntity is null)
        {
            throw new WebShopException($"Error during mapping {nameof(UserResponse)} to {nameof(UserEntity)}");
        }

        await _repository.AddEntity(newUserEntity, cancellationToken);

        var result = _mapper.Map<UserResponse>(newUserEntity);

        return result;
    }
}