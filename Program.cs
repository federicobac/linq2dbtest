using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=./development.db";
var options = DataOptionsExtensions.UseSQLite(new DataOptions(), connectionString);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
