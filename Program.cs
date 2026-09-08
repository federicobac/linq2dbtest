using linq2dbtest;
using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB") ?? "Data Source=./development.db";
var options = new DataOptions().UseSQLite(connectionString);
var dataOptions = new DataOptions<MyAmazingDatabase>(options);

//New connection every http request
builder.Services.AddScoped<MyAmazingDatabase>(_ => new MyAmazingDatabase(dataOptions));
//New connection every constructor

builder.Services.AddOpenApiDocument();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyAmazingDatabase>();
    db.CreateTable<MyAmazingEntity>(tableOptions: TableOptions.CreateIfNotExists);
}

app.MapGet("/", (MyAmazingDatabase db) => db.MyAmazingEntities().ToList());

app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();

app.Run();

