using Microsoft.EntityFrameworkCore;
using SoftwareArchitectureDesignAPI.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using SoftwareArchitectureDesignAPI.Business.AutofacDependencies;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

builder.Services.AddControllers();

// Add services to the container.

//DB CONTEXT POOL IS BETTER FOR PERFORMANCE - LOOKS FOR EXISTING CONTEXTS RATHER THAN MAKE A NEW ONE EVERYTIME 
/*builder.Services.AddDbContextPool<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddScoped<IDataContext, DataContext>();*/

builder.Services.AddDbContextFactory<DataContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();