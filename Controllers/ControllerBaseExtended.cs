using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers
{
  public class ControllerBaseExtended : ControllerBase
  {
    protected readonly ILogger _logger;

    public ControllerBaseExtended(ILogger logger)
    {
      _logger = logger;
    }
  }
}