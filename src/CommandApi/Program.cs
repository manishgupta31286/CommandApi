using CommandApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommandContext>(opt=>opt.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgreSqlConnection")
));
builder.Services.AddControllers();
builder.Services.AddScoped<ICommandApiRepo,SqlCommandApiRepo>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints=>{
    endpoints.MapControllers();
});

//dotapp.MapGet("/", () => "Hello World!");

app.Run();
