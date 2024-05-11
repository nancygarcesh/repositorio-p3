using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using bussineslogic1.Manager;
using Practice3.Middlewares;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API for Practice 3", Version = "v1" });
        });

        builder.Services.AddSingleton<PatientManager1>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "QA")
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API for Practice 3 V1");
            });
        }
        app.UseErrorLogging();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
