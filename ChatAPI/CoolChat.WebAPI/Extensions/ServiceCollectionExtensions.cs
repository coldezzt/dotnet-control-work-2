using AutoMapper;
using CoolChat.Application.Abstractions.Repositories;
using CoolChat.Application.Services;
using CoolChat.Domain.Abstractions.Services;
using CoolChat.Infrastructure;
using CoolChat.Infrastructure.Repositories;
using CoolChat.WebAPI.Configurations.Mapper;
using CoolChat.WebAPI.Dto;
using CoolChat.WebAPI.Dto.Validators;
using FluentValidation;

namespace CoolChat.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguredDatabase(this IServiceCollection services)
    {
        services.AddSingleton<ApplicationDbContext>();

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMessageRepository, MessageRepository>();

        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageService, MessageService>();

        return services;
    }

    public static IServiceCollection AddConfiguredSignalR(this IServiceCollection services)
    {
        services.AddSignalR();
        
        return services;
    }
    
    public static IServiceCollection AddConfiguredSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen();

        return services;
    }
    
    public static IServiceCollection AddConfiguredAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfiles( new List<Profile>
                {
                    new MessageMapperProfile(),
                }
            );
        });

        return services;
    }
    
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<MessageDto>, MessageDtoValidator>();
        
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop; 
        
        return services;
    }
}