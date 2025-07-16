using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Endpoint.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddHimartSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var files = Directory.GetFiles(AppContext.BaseDirectory,
                                           $"Endpoint.*.xml",
                                           new EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive }).ToList();
            foreach (var file in files)
                options.IncludeXmlComments(file);

            var assemblyVersion = typeof(SwaggerExtensions).Assembly.GetName().Version;

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Himart API",
                Version = assemblyVersion?.ToString(3),
                Contact = new OpenApiContact
                {
                    Name = "Himart team"
                }
            });

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
        });

        return services;
    }

    public static IApplicationBuilder UseHimartSwagger(this IApplicationBuilder app, WebApplication webApplication)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Himart API V1");
            options.EnableDeepLinking();
            options.EnableFilter();
            options.DisplayRequestDuration();
        });
        return app;
    }
}
