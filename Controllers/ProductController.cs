using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;
using DotNetWebApiSupport.Interfaces;

namespace DotNetWebApiSupport.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private readonly Settings _settings;
  private readonly IRepository<Product> _repo;
  private readonly IConfiguration _config;

  public ProductController(Settings settings, IRepository<Product> repo, IConfiguration config)
  {
    _settings = settings;
    _repo = repo;
    _config = config;

    // Illustration d'accès à un Setting
    _config = config;
    // Lecture du setting 'UserMessageDefault'
    string message = _config["DotNetWebApiSupport:UserMessageDefault"]
      ?? string.Empty;
    message = message.Replace("{verb}", "GET")
  .Replace("{className}", "Product");
    System.Diagnostics.Debug.WriteLine(message);
  }

  [HttpGet]
  [Route("")]
  [Route("GetAllProducts")]
  [Route("GetProductsList")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public ActionResult<List<Product>> Get()
  {
    // System.Diagnostics.Debug.WriteLine(_settings.MyPropertyTest);
    List<Product> list;
    list = _repo.Get();
    return StatusCode(StatusCodes.Status200OK, list);
  }

  [HttpGet]
  [Route("GetList")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  public ActionResult<List<Product>> GetList()
  {
    List<Product> list;
    list = _repo.Get();
    return StatusCode(StatusCodes.Status200OK, list);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public ActionResult<Product?> Get(int id)
  {
    Product? entity;

    entity = _repo.Get(id);
    if (entity != null)
    {
      return Ok(entity);
    }
    else
    {
      return NotFound($"Can't find Product with a Product Id of '{id}'.");
    }
  }

  [HttpGet]
  [Route("ByCategory/{categoryId}")]
  public ActionResult<IEnumerable<Product>> SearchByCategory(int categoryId)
  {
    // TODO: recherche par catégorie à implémenter
    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpGet]
  [Route("ByNameAndPrice/Name/{name}/Price/{price}")]
  public ActionResult<IEnumerable<Product>> SearchByNameAndPrice(string name, decimal price)
  {
    // TODO: recherche par catégorie à implémenter
    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpGet]
  [Route("ByNameAndPrice")]
  public ActionResult<IEnumerable<Product>> SearchByNameAndPriceQS(string name, decimal price)
  {
    // TODO: recherche par catégorie à implémenter
    return StatusCode(StatusCodes.Status200OK);
  }
}
