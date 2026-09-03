using linq2dbtest;
using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=./development.db";
var options = new DataOptions().UseSQLite(connectionString);
var dataOptions = new DataOptions<MyAmazingDatabase>(options);

builder.Services.AddScoped<MyAmazingDatabase>(_ => new MyAmazingDatabase(dataOptions));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
