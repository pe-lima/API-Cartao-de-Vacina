﻿using BTG.Vacinacao.Core.Interfaces.Repositories;
using BTG.Vacinacao.Infra.Context;
using BTG.Vacinacao.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BTG.Vacinacao.Infra.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
            
            // ( Repositories )
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IVaccineRepository, VaccineRepository>();
            services.AddScoped<IVaccinationRepository, VaccinationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // ( Unit of Work )
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
