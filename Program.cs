using linq2dbtest;
using LinqToDB;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB") ?? "Data Source=./development.db";
var options = new DataOptions().UseSQLite(connectionString);
var dataOptions = new DataOptions<MyDatabaseConnection>(options);

//New connection every http request
builder.Services.AddScoped<MyDatabaseConnection>(_ => new MyDatabaseConnection(dataOptions));
//New connection every constructor


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDatabaseConnection>();
    db.CreateTable<MyAmazingEntity>(tableOptions: TableOptions.CreateIfNotExists);
}

app.MapGet("/", (MyDatabaseConnection dbc) =>dbc.MyAmazingEntities().ToList());

app.Run();
