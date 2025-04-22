using Budget.Application.Database;
using Budget.Application.Repositories;
using Budget.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddSingleton<IIncomeRepository, IncomeRepository>();
            services.AddSingleton<IExpenseRepository, ExpenseRepository>();
            services.AddSingleton<IIncomeService, IncomeService>();
            services.AddSingleton<IExpenseService, ExpenseService>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDbConnectionFactory>(_ => 
                new NpqsqlConnectionFactory(connectionString));
            services.AddSingleton<DbInitializer>();
            return services;
        }
    }
}
