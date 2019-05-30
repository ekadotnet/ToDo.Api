using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ToDo.Data.Context;
using ToDo.Data.Dtos;

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

        public bool Delete(int entity)
        {
            var task = _toDoContext.ToDoTasks.FirstOrDefault(x => x.Id == entity);

            if (task == null)
            {
                return false;
            }

            _toDoContext.ToDoTasks.Remove(task);
            var result = _toDoContext.SaveChanges();

            return result > 0;
        }

    }
}
