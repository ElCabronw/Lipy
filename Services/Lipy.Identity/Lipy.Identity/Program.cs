using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Lipy.Identity.Configuration;
using Lipy.Identity.Models;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbConfig)).Get<MongoDbConfig>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Identity Api",
        Description = "Api to manipulate the Users and Roles",
        Contact = new OpenApiContact
        {
            Name = "Lucas Fuziyama",
            Email = "lucasfuziyama@gmail.com"
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
