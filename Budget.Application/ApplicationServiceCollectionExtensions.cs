using Budget.Application.Repositories;
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
            return services;
        }
    }
}
