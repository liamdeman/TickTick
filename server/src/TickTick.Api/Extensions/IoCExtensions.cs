using MediatR;
using TickTick.Models;
using TickTick.Repositories;
using TickTick.Repositories.Base;

namespace TickTick.Api;

public static class IoCExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Person>, Repository<Person>>();
        services.AddTransient<IRepository<Playlist>, Repository<Playlist>>();
        services.AddTransient<IRepository<Song>, Repository<Song>>();
        services.AddTransient<IRepository<Speech>, Repository<Speech>>();
        services.AddMediatR(typeof(IoCExtensions));
        services.AddAutoMapper(typeof(IoCExtensions));

        return services;
    }
}