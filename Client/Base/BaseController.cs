using Client.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Client.Base;

public class BaseController<Entity, Repository, Id> : Controller
    where Entity : class
    where Repository : IRepository<Entity, Id>
{
    private readonly Repository repository;

    public BaseController(Repository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public async Task<JsonResult> GetAll()
    {
        var result = await repository.Get();
        return Json(result);
    }

    [HttpGet]
    public async Task<JsonResult> Get(Id id)
    {
        var result = await repository.Get(id);
        return Json(result);
    }

    [HttpPost]
    public JsonResult Post(Entity entity)
    {
        var result = repository.Post(entity);
        return Json(result);
    }

    [HttpPut]
    public JsonResult Put(Id id, Entity entity)
    {
        var result = repository.Put(entity, id);
        return Json(result);
    }

    [HttpDelete]
    public JsonResult Delete(Id id)
    {
        var result = repository.Delete(id);
        return Json(result);
    }
}
