using RestAPI.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPI.Model.Services.Implementation
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try 
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            _context.Remove(person);
            _context.SaveChanges();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = _context.Persons.ToList();      
            return persons;
        }
               
        public Person FindById(long id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            return person;
        }

        public Person Update(Person person)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }                

            return person;
        }
    }
}
