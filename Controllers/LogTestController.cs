using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DotNetWebApiSupport.EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LogTestController : ControllerBase
  {
    private ILogger<LogTestController> _logger;

    public LogTestController(ILogger<LogTestController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public string WriteMessages()
    {
      _logger.LogTrace("Trace");
      _logger.LogError("Erreur");
      return "regardez les logs";
    }

    [HttpGet]
    [Route("LogObject")]
    public string LogObject()
    {
      Product p = new()
      {
        ProductID = 888,
        Name = "TST"
      };
      string json = JsonSerializer.Serialize<Product>(p);
      _logger.LogInformation("Product = {json}", json);
      return "regardez les logs";
    }
  }
}