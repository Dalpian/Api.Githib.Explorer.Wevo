using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using Wevo.Github.Explore.Domain.Interfaces.Services;
using Wevo.Github.Explorer.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wevo.Github.Explore.Domain.Interfaces;
using Wevo.Github.Explorer.Infra.Data.UoW;
using Wevo.Github.Explore.Domain.Interfaces.Repositories;
using Wevo.Github.Explorer.Infra.Data.Repositories;
using MediatR;
using FluentValidation;
using Vivan.Mediator.PipelineBehavior;
using Vivan.Notifications.Interfaces;
using Vivan.Notifications.Contexts;
using Wevo.Github.Explorer.Infra.Data.Services;

namespace Wevo.Github.Explore.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        private const string DommainAssemblyName = "Wevo.Github.Explorer.Domain";

        public static void RegisterServices(this IServiceCollection services, string applicationAssemblyName, IConfiguration configuration)
        {
            //Notifications
            services.AddScoped<INotificationContext, NotificationContext>();

            //Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.Load(applicationAssemblyName));

            //Services
            services.AddScoped<IUserService, UserGithubService>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<GithubExplorerContext>(options =>
            {
                options.UseNpgsql(configuration["ConnectionStrings:Npgsql"], x => x.UseNetTopologySuite());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            //Settings
            RegisterMediatr(services);
        }

        private static void RegisterMediatr(IServiceCollection services)
        {
            //MediatR
            var assembly = AppDomain.CurrentDomain.Load(DommainAssemblyName);

            services.AddMediatR(assembly);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}