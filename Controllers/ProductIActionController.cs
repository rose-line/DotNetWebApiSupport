using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductIActionController : ControllerBase
{
  [HttpGet]
  public IActionResult Get()
  {
    List<Product> list;
    list = new ProductRepository().Get();
    return StatusCode(StatusCodes.Status200OK, list);
  }

  [HttpGet("{id}")]
  public IActionResult Get(int id)
  {
    IActionResult ret;
    Product? entity;

    entity = new ProductRepository().Get(id);
    if (entity != null)
    {
      ret = StatusCode(StatusCodes.Status200OK, entity);
    }
    else
    {
      ret = StatusCode(StatusCodes.Status404NotFound, $"Can't find Product with a Product Id of '{id}'.");
    }

    return ret;
  }
}
