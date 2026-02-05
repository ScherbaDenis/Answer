using Answer.Application.Interfaces;
using Answer.Domain.Entities;
using Answer.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Answer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IRepository<User>, InMemoryRepository<User>>();
        services.AddSingleton<IRepository<Question>, InMemoryRepository<Question>>();
        services.AddSingleton<IRepository<Template>, InMemoryRepository<Template>>();
        services.AddSingleton<IRepository<Domain.Entities.Answer>, InMemoryRepository<Domain.Entities.Answer>>();
        
        return services;
    }
}
