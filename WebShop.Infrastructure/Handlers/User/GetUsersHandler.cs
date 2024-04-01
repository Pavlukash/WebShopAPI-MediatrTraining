using AutoMapper;
using MediatR;
using WebShop.DataAccess.Contracts;
using WebShop.DataAccess.Extensions;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Requests.User;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Handlers.User;

public sealed class GetUsersHandler: IRequestHandler<GetUsersQuery, PagedList<UserResponse>>
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetUsersHandler(IRepository<UserEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<PagedList<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var userEntities = await _repository
            .QueryAll(false)
            .FilterOrder(request.OrderFilter)
            .ToPagedListAsync(request.PageFilter, cancellationToken);

        var result = _mapper.Map<PagedList<UserResponse>>(userEntities);

        return result;
    }
}