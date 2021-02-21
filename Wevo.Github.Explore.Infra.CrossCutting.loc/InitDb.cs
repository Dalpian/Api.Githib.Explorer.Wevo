using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Wevo.Github.Explorer.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Wevo.Github.Explore.Infra.CrossCutting.Ioc
{
    public static class InitDb
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<GithubExplorerContext>())
                {
                    context.Database.Migrate();
                }
            }

        }
    }
}
