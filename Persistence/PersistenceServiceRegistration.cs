﻿using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FlickVerseDb")));
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("BaseDb"));


        services.AddScoped<ILanguageRepository, LanguageRepository>();

        return services;
    }
}
