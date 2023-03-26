using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Abp.Pschool.Data;
using Volo.Abp.DependencyInjection;

namespace Abp.Pschool.EntityFrameworkCore;

public class EntityFrameworkCorePschoolDbSchemaMigrator
    : IPschoolDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCorePschoolDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the PschoolDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<PschoolDbContext>()
            .Database
            .MigrateAsync();
    }
}
