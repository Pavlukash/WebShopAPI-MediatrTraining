using AutoMapper;
using MediatR;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Requests.User;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Handlers.User;

public class EditUserHandler : IRequestHandler<EditUserCommand, UserResponse>
{
    private readonly IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;

    public EditUserHandler(IRepository<UserEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id, false, cancellationToken);

        user.Name = request.Name ?? user.Name;
        user.Email = request.Email ?? user.Email;
        user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;

        await _repository.SaveChangesAsync(cancellationToken);

        var result = _mapper.Map<UserResponse>(user);

        return result;
    }
}