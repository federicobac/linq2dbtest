using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace linq2dbtest;

public class MyAmazingController(MyAmazingDatabase db)
{
    [HttpGet(nameof(GetEntities))]
    public List<MyAmazingEntity> GetEntities()
    {
        return db.MyAmazingEntities().ToList();
    }
    
    [HttpPost(nameof(PostEntities))]
    public void PostEntities([FromQuery] string id, [FromQuery] string propertyValue)
    {
        db.Insert(new MyAmazingEntity()
        {
            Id = id,
            MyProperty = propertyValue
        });
    }
    
    [HttpDelete(nameof(DeleteEntities))]
    public void DeleteEntities([FromQuery] string id)
    {
        var entity = db.MyAmazingEntities().First(g => g.Id == id);
        db.Delete(entity);
    }
}