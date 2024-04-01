using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebShop.DataAccess.Repositories;
using WebShop.DataAccess.Repositories.Interfaces;
using WebShop.Domain.Contexts;
using WebShop.Domain.Entities.User;
using WebShop.Infrastructure.Mapping;
using WebShopAPI_MediatrTraining.Endpoints;
using WebShopAPI_MediatrTraining.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    x => x.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "WebShopAPI-MediatrTraining",
            Version = "v1"
        }));

builder.Services.AddAutoMapper(typeof(EntityToResponseProfile), typeof(RequestToEntityProfile));

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebShopContext>(opt =>
{
    opt.UseSqlServer(connection, x => x.MigrationsAssembly("WebShop.API"));
});
        
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapUserEndpoints();

app.Run();


