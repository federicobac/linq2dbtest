using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace linq2dbtest;

public class MyAmazingEntity
{
    [PrimaryKey]public string Id { get; set; }
    public string MyProperty { get; set; }
}

public class MyAmazingDatabase(DataOptions<MyAmazingDatabase> opts) : DataConnection(opts.Options)
{
    public ITable<MyAmazingEntity> MyAmazingEntities() => this.GetTable<MyAmazingEntity>();
}
