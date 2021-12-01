using ESGApiPlatform.Repository;
using ESGApiPlatform.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEsgApiRepository, EsgApiRepository>();
            services.AddScoped<IEsgApiService, EsgApiService>();
        }
    }
}
