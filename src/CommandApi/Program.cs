using CommandApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ICommandApiRepo,MockCommandApiRepo>();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints=>{
    endpoints.MapControllers();
});

//dotapp.MapGet("/", () => "Hello World!");

app.Run();
