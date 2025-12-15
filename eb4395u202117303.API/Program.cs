using eb4395u202117303.API.Assets.Infrastructure.Persistence;
using eb4395u202117303.API.Operations.Application.ACL;
using eb4395u202117303.API.Operations.Infrastructure.ACL;
using eb4395u202117303.API.Operations.Infrastructure.Persistence;
using eb4395u202117303.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FIRSTstudent API",
        Version = "v1",
        Description = "API for FIRSTstudent Inc. operations.",
        Contact = new OpenApiContact 
        { 
            Name = "Joan Fernando Teves Samaniego", 
            Email = "u202117303@upc.edu.pe" 
        }
    });
    c.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<AssetsDbContext>(options => {
    options.UseMySQL(connectionString);
    options.AddCreatedUpdatedInterceptor(); 
});

builder.Services.AddDbContext<OperationsDbContext>(options => {
    options.UseMySQL(connectionString);
    options.AddCreatedUpdatedInterceptor();
});

builder.Services.AddScoped<IBusContextFacade, BusContextFacade>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var assets = services.GetRequiredService<AssetsDbContext>();
    var operations = services.GetRequiredService<OperationsDbContext>();
    
    assets.Database.EnsureCreated();
    operations.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();