using Lipy.HeaderApi.Interfaces;
using Lipy.HeaderApi.Model.Context;
using Lipy.HeaderApi.Persistence;
using Lipy.HeaderApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    var serializerOptions = opt.JsonSerializerOptions;
                    serializerOptions.IgnoreReadOnlyProperties = false;
                    serializerOptions.WriteIndented = true;
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

HeaderDbPersistence.Configure();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Header Api",
        Description = "Api to manipulate the Header of Lipy News",
        Contact = new OpenApiContact
        {
            Name = "Lucas Fuziyama",
            Email = "lucasfuziyama@gmail.com"
        }
    });
});

builder.Services.AddScoped<IHeaderDbContext,HeaderDbContext>();
builder.Services.AddScoped<IHeaderRepository,HeaderRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();

//}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
app.UseSwaggerUI();
app.Run();
