using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestAPI.Model.Base;
using RestAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T: BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {           
            _context = context;            
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            var person = dataset.SingleOrDefault(p => p.Id == id);
            _context.Remove(person);
            _context.SaveChanges();
        }

        public List<T> FindAll()
        {
            List<T> persons = dataset.ToList();
            return persons;
        }

        public T FindById(long id)
        {
            var person = dataset.SingleOrDefault(p => p.Id == id);
            return person;
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id == item.Id);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }

            return item;
        }
    }
}
