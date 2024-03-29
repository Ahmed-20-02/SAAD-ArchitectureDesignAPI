using Microsoft.EntityFrameworkCore;
using SoftwareArchitectureDesignAPI.Data;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using SoftwareArchitectureDesignAPI.Business.AutofacDependencies;

var builder = WebApplication.CreateBuilder(args);

////Reference
//https://stackoverflow.com/questions/69754985/adding-autofac-to-net-core-6-0-using-the-new-single-file-template/71448702#71448702
//02/01/2024
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

builder.Services.AddControllers();

// Add services to the container.

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