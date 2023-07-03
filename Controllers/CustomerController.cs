using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.Interfaces;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBaseExtended
  {
    private IRepository<Customer> _repo;

    public CustomerController(IRepository<Customer> repo, ILogger logger) : base(logger)
    {
      _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Customer>> Get()
    {
      List<Customer> list;
      list = _repo.Get();
      return StatusCode(StatusCodes.Status200OK, list);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Customer?> Get(int id)
    {
      Customer? entity;

      entity = _repo.Get(id);
      if (entity != null)
      {
        return Ok(entity);
      }
      else
      {
        return NotFound($"Can't find Customer with a Customer Id of '{id}'.");
      }
    }

    [HttpGet]
    [Route("ByTitle")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Customer>> SearchByTitle(string title)
    {
      ActionResult<IEnumerable<Customer>> res;

      IEnumerable<Customer> list = _repo.Get()
          .Where(customer => customer.Title == title)
          .OrderBy(customer => customer.LastName);

      res = StatusCode(StatusCodes.Status200OK, list);
      return res;
    }

    [HttpGet]
    [Route("ByFirstAndLastName/First/{firstName:alpha:maxlength(50)}/Last/{lastName:alpha:maxlength(50)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Customer>> SearchByFirstAndLastName(string firstName, string lastName)
    {
      ActionResult<IEnumerable<Customer>> res;

      IEnumerable<Customer> list = _repo.Get()
          .Where(customer => customer.FirstName.Contains(firstName, StringComparison.InvariantCultureIgnoreCase)
              && customer.LastName.Contains(lastName, StringComparison.InvariantCultureIgnoreCase))
          .OrderBy(customer => customer.LastName)
          .ThenBy(customer => customer.FirstName);

      res = StatusCode(StatusCodes.Status200OK, list);
      return res;
    }
  }
}