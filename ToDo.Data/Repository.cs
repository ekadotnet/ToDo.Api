using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ToDo.Data.Context;

namespace ToDo.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ToDoContext _toDoContext;

        public Repository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }




        public IEnumerable<T> Get()
        {
            return _toDoContext.Set<T>().ToList();
        }

        

        public T Add(T entity)
        {
            
            _toDoContext.Set<T>().Add(entity);
            _toDoContext.SaveChanges();

            return entity;
        }

        

        public T Update(T entity)
        {
            _toDoContext.Set<T>().Update(entity);
            _toDoContext.SaveChanges();

            return entity;
        }

        public T Delete(T entity)
        {
            _toDoContext.Set<T>().Remove(entity);
            _toDoContext.SaveChanges();

            return entity;
        }



    }
}
