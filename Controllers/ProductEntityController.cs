﻿using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductEntityController : ControllerBase
{
  [HttpGet]
  public List<Product> Get()
  {
    List<Product> list;

    list = new ProductRepository(null).Get();

    return list;
  }

  [HttpGet("{id}")]
  public Product? Get(int id)
  {
    Product? entity;

    entity = new ProductRepository(null).Get(id);

    return entity;
  }
}
