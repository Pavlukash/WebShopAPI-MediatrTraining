using MediatR;
using WebShop.DataAccess.Contracts;
using WebShop.DataAccess.Contracts.Filters;
using WebShop.Infrastructure.Responses;

namespace WebShop.Infrastructure.Requests.User;

public sealed record GetUsersQuery(OrderFilter OrderFilter, PageFilter PageFilter) : IRequest<PagedList<UserResponse>>;