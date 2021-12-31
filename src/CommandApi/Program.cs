using CommandApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<CommandContext>(opt=>opt.UseNpgsql(
//     builder.Configuration.GetConnectionString("PostgreSqlConnection")
// ));
var npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder();
npgsqlConnectionStringBuilder.ConnectionString=builder.Configuration.GetConnectionString("PostgreSqlConnection");
npgsqlConnectionStringBuilder.Username=builder.Configuration["UserID"];
npgsqlConnectionStringBuilder.Password=builder.Configuration["Password"];

builder.Services.AddDbContext<CommandContext>(opt=>opt.UseNpgsql(npgsqlConnectionStringBuilder.ConnectionString));

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICommandApiRepo,SqlCommandApiRepo>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints=>{
    endpoints.MapControllers();
});

//dotapp.MapGet("/", () => "Hello World!");

app.Run();
