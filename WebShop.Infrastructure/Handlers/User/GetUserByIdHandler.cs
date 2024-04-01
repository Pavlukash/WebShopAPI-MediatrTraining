using AutoMapper;
using MediatR;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Requests.User;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Handlers.User;

public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IRepository<UserEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userEntity = await _repository.GetById(request.Id, false, cancellationToken);

        var result = _mapper.Map<UserResponse>(userEntity);

        return result;
    }
}