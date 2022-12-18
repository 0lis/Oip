using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;

namespace Microsoft.Extensions.DependencyInjection;

public static class WebApplicationExtension
{
    public static WebApplication BuildOip(this WebApplicationBuilder builder)
    {
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        return app;
    }
}