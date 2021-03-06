using FluentMigrator.Runner;

namespace CA.Assessment.WebAPI.Host;

internal sealed class MigrationsHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationsHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using var serviceScope = _serviceProvider.CreateScope();

        var migrator = serviceScope.ServiceProvider.GetRequiredService<IMigrationRunner>();

        migrator.MigrateUp();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
