using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using TickTick.Api;
using TickTick.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddDbContext<TickTickDbContext>(options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        
        builder.Services.AddControllers(opt => { opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>(); })
            .AddOData(options =>
                options.AddRouteComponents(new EdmModel()).Select().OrderBy().Filter().Expand()
                    .SetMaxTop(null).Count());
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "TickTick your ticks and tickles",
                    Version = "v1",
                    Description = "lorem ipsim sit dolar amet",
                    Contact = new OpenApiContact
                    {
                        Name = "Kevin DeRudder",
                        Email = "kevin.derudder@gmail.com",
                        Url = new Uri("https://chat.opeanai.com")
                    }
                });
        });
        builder.Services.AddApiVersioning(config => {
            config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
        });
        

        builder.Services.RegisterServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}