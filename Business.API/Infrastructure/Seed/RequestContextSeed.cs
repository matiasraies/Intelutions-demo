using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using Request.Domain.AggregatesModel.Permission;
using Request.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Infrastructure.Seed
{
    public class RequestContextSeed
    {
        /// <summary>
        /// Migracion y carga de la base de datos.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="env"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public async Task SeedAsync(RequestContext context, IWebHostEnvironment env, IOptions<RequestSettings> settings)
        {
            var policy = CreatePolicy(nameof(RequestContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                var contentRootPath = env.ContentRootPath;

                using (context)
                {
                    context.Database.Migrate();

                    if (!context.PermissionTypes.Any())
                    {
                        context.PermissionTypes.AddRange(GetPredefinedPermissionTypes());
                        await context.SaveChangesAsync();
                    }

                    await context.SaveChangesAsync();
                }
            });
        }

        /// <summary>
        /// Define los PermissionTypes por defecto de la base de datos.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<PermissionType> GetPredefinedPermissionTypes()
        {
            return new List<PermissionType>
            {
                new PermissionType("Permiso alto"),
                new PermissionType("Permiso medio"),
                new PermissionType("Permiso bajo")
            };
        }

        /// <summary>
        /// Define la politica a utilizar ante una Excepcion del tipo SqlException.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="retries"></param>
        /// <returns></returns>
        private AsyncRetryPolicy CreatePolicy(string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5)
                );
        }
    }
}
