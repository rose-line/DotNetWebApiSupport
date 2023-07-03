using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductIActionController : ControllerBase
{
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public IActionResult Get()
  {
    List<Product> list;
    list = new ProductRepository(null).Get();
    return StatusCode(StatusCodes.Status200OK, list);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public IActionResult Get(int id)
  {
    IActionResult ret;
    Product? entity;

    entity = new ProductRepository(null).Get(id);
    if (entity != null)
    {
      ret = Ok(entity);
    }
    else
    {
      ret = NotFound($"Can't find Product with a Product Id of '{id}'.");
    }

    return ret;
  }
}
