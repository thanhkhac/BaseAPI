using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

namespace CompanyEmployees;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        builder.Services.ConfigureCors();
        builder.Services.ConfigureIisIntegration();
        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
        else { app.UseHsts(); }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.All
        });

        app.UseCors("CorsPolicy");

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}