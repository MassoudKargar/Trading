using Base.Extensions.Caching.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Trading.Endpoints.API.Extensions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        builder.AddObservability();
        builder.Services.AddSingleton<CommandDispatcherDecorator, CustomCommandDecorator>();
        builder.Services.AddSingleton<QueryDispatcherDecorator, CustomQueryDecorator>();
        builder.Services.AddSingleton<EventDispatcherDecorator, CustomEventDecorator>();
        builder.Services.AddBaseApiCore("Base", "Trading");
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddBaseWebUserInfoService(configuration, "WebUserInfo", true);
        builder.Services.AddBaseParrotTranslator(configuration, "ParrotTranslator");
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddBaseMicrosoftSerializer();
        builder.Services.AddBaseAutoMapperProfiles(option =>
        {
            option.AssemblyNamesForLoadProfiles = "Trading";
        });
        //cacheAdapter.Add(Key, Value, DateTime.Now.AddDays(1), null);
        builder.Services.AddBaseRedisDistributedCache(configuration, "Redis");

        builder.Services.AddDbContext<TradingCommandDbContext>(c => c
            .UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
            .AddInterceptors(new SetPersianYeKeInterceptor(), new AddAuditDataInterceptor()));
        builder.Services.AddDbContext<TradingQueryDbContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("QueryDb_ConnectionString")));
        builder.Services.AddScoped<TradingCommandDbContextFactory>();

        builder.Services.AddIdentityServer(configuration, "OAuth");

        builder.Services.AddOpenApiDocumentation(configuration, "OpenApi");
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app, string[] args)
    {
        var runMigrations = args.Contains("--migrate");
        if (runMigrations)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<TradingQueryDbContext>();
            db.Database.Migrate();
        }
        app.UseBaseObservabilityMiddleware();
        app.UseBaseApiExceptionHandler();
        app.UseOpenApiDocumentation("OpenApi");
        app.UseStatusCodePages();
        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
        app.UseHttpsRedirection();
        app.MapControllers();
        return app;
    }
}