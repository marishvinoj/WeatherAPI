using Microsoft.EntityFrameworkCore;
using WeatherAPI;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var server = builder.Configuration["DBServer"] ?? "localhost";//"ms-sql-server";//?? "localhost";//
var port = builder.Configuration["DBPort"] ?? "1434";
var user = builder.Configuration["DBUser"] ?? "SA";
var password = builder.Configuration["DBPassword"] ?? "Test@12345#";//"Tiger@12345";// 
var database = builder.Configuration["Database"] ?? "TestDB";

string ConnString= "Data Source=localhost;Initial Catalog=VSM_Divine;User ID=sa;Password=Tiger@12345";

builder.Services.AddDbContext<ColourContext>(options =>
{
    //options
    //.UseSqlServer(ConnString);
    //Data Source = localhost,1434; Initial Catalog = TestDB; Persist Security Info = True; User ID = SA
    options
    .UseSqlServer($"Server={server},{port};Initial Catalog={database};TrustServerCertificate=True; User ID={user};Password={password}");
});

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
