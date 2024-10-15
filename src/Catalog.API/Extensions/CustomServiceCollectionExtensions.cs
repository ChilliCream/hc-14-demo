namespace Microsoft.Extensions.DependencyInjection;

public static class CustomServiceCollectionExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(
        this IHostApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices(
            builder.Configuration.GetConnectionString("CatalogDB"));
        return builder;
    }
    
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        string? connectionString = null)
    {
        services
            .AddDbContextPool<CatalogContext>(
                o => o.UseNpgsql(connectionString));

        services
            .AddMigration<CatalogContext, CatalogContextSeed>();

        return services;
    }
}