using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebShop.DataAccess.Contracts.Filters;
using WebShop.Infrastructure.Requests.User;
using WebShop.Infrastructure.Responses;

namespace WebShopAPI_MediatrTraining.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGroup("user")
            .MapEndpoints();
    }

    private static RouteGroupBuilder MapEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetUsers)
            .Produces<List<UserResponse>>();

        group.MapGet("/{userId:int}", GetUserById)
            .Produces<UserResponse>();

        group.MapPost("/", CreateUser)
            .Produces<UserResponse>();

        group.MapPut("/", EditUser)
            .Produces<UserResponse>();
        
        group.MapDelete("/{userId}", DeleteUser)
            .Produces<bool>();

        return group;
    }

    private static async Task<IResult> GetUsers(
        IMediator mediator,
        [AsParameters] OrderFilter orderFilter, 
        [AsParameters] PageFilter pageFilter,
        CancellationToken cancellationToken)
    {
        var query = new GetUsersQuery(orderFilter, pageFilter);
        var result = await mediator.Send(query, cancellationToken);

        return Results.Ok(result);
    }

    private static async Task<IResult> GetUserById(
        IMediator mediator, 
        int userId, 
        CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(userId);
        var result = await mediator.Send(query, cancellationToken);

        return Results.Ok(result);
    }

    private static async Task<IResult> CreateUser(
        IMediator mediator, 
        [FromBody] CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Results.Ok(result);
    }

    private static async Task<IResult> EditUser(
        IMediator mediator, 
        [FromBody] EditUserCommand command, 
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Results.Ok(result);
    }

    private static async Task<IResult> DeleteUser(
        IMediator mediator, 
        int userId, 
        CancellationToken cancellationToken)
    {
        var query = new DeleteUserCommand(userId);
        var result = await mediator.Send(query, cancellationToken);

        return Results.Ok(result);
    }
}