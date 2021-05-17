using Database.FluentMigrator;
using Database.Interfaces;
using Database.Mappings;
using Dominio.Configurations;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Database.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddNHibernate(services, configuration);

            AddRepositories(services);

            AddFluentMigrator(services, configuration);

            services
                .ConfigureRunner(rb => rb
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(VersionTable).Assembly)
                    .For.Migrations()
                    .For.EmbeddedResources());

            services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
            services.Configure<ClientSettings>(settings =>
            {
                settings.ProjetoWebUrl = configuration["ClientSettings:projetoWebUrl"];
            });

            return services;
        }

        private static void AddNHibernate(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISessionFactory>((serviceProvider) =>
            {
                var settings = configuration.GetSection("NHibernateConfig")
                                        .GetChildren()
                                        .ToDictionary(x => x.Key, x => x.Value);

                var nhConfiguration = new Configuration();
                nhConfiguration.AddProperties(settings);

                var mapper = new ModelMapper();

                mapper.AddMappings(typeof(AnuncioMap).Assembly.ExportedTypes);
                HbmMapping mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();

                mappings.autoimport = false;
                nhConfiguration.AddMapping(mappings);

                return nhConfiguration.BuildSessionFactory();
            });

            services.AddScoped<ISession>((serviceProvider) =>
            {
                var sessionFactory = serviceProvider.GetService<ISessionFactory>();
                var session = sessionFactory.OpenSession();

                return session;
            });

            services.AddScoped<IStatelessSession>((serviceProvider) =>
            {
                var sessionFactory = serviceProvider.GetService<ISessionFactory>();
                var statelessSession = sessionFactory.OpenStatelessSession();

                return statelessSession;
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore()
                    .ConfigureRunner(runnerBuilder =>
                    {
                        runnerBuilder.AddSqlServer2016()
                                     .WithGlobalConnectionString(configuration["NHibernateConfig:connection.connection_string"])
                                     .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
                                     .WithVersionTable(new VersionTable());
                    })
                    .AddLogging(loggingBuilder => loggingBuilder.AddFluentMigratorConsole());
        }
    }
}
