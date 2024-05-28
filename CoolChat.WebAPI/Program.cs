using CoolChat.WebAPI.Controllers.Hubs;
using CoolChat.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConfiguredDatabase()
    .AddServices()
    .AddRepositories()
    .AddValidators()
    .AddConfiguredSignalR()
    .AddConfiguredSwaggerGen()
    .AddConfiguredAutoMapper();

builder.Services
    .AddControllers();

var application = builder.Build();

application
    .UseSwagger()
    .UseSwaggerUI();

application.UseHttpsRedirection();

application.MapControllers();
application.MapHub<ChatHub>("/chat");

application.Run();
