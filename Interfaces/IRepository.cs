using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetWebApiSupport.Interfaces
{
  public interface IRepository<T>
  {
    List<T> Get();
    T? Get(int id);
    T Insert(T entity);
  }
}