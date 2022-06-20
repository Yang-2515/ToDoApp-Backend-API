using System;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Infrastructure;
using ToDoApp.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApplicationTier.Domain.Models;
using AppContext = ToDoApp.Infrastructure.AppContext;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Infrastructure.Repositories;
using ToDoApp.Domain.Base;

namespace ToDoApp.API.Extensions
{
	public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add needed instances for database
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            // Configure DbContext with Scoped lifetime   
            services.AddDbContext<AppContext>(options =>
                {
                    options.UseSqlServer(AppSettings.ConnectionString,
                        sqlOptions => sqlOptions.CommandTimeout(120));
                    options.UseLazyLoadingProxies();
                }
            );

            services.AddScoped<Func<AppContext>>((provider) => () => provider.GetService<AppContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ILabelRepository, LabelRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITaskRepository, TaskRepository>()
                .AddScoped<ITaskLabelRepository, TaskLabelRepository>()
                .AddScoped<IBoardMemberRepository, BoardMemberRepository>()
                .AddScoped<IBoardRepository, BoardRepository>()
                .AddScoped<IAssignmentRepository, AssignmentRepository>()
                .AddScoped<IAttackmentRepository, AttackmentRepository>()
                .AddScoped<IListTaskRepository, ListTaskRepository>();
        }

        /// <summary>
        /// Add instances of in-use services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<ILabelService, LabelService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITaskLabelService, TaskLabelService>()
                .AddScoped<ITaskService, TaskService>()
                .AddScoped<IBoardService, BoardService>()
                .AddScoped<IBoardMemberService, BoardMemberService>()
                .AddScoped<IListTaskService, ListTaskService>()
                .AddScoped<IAssignmentService, AssignmentService>()
                .AddScoped<IAttackmentService, AttackmentService>();
        }

        /// <summary>
        /// Add CORS policy to allow external accesses
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            return // CORS
                services.AddCors(options => {
                    options.AddPolicy("CorsPolicy",
                        builder => {
                            builder.WithOrigins(AppSettings.CORS)
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                        });
                });
        }
    }
}
