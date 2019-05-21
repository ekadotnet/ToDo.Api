using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
