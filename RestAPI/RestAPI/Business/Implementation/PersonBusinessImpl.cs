﻿using RestAPI.Repository.Context;
using RestAPI.Respository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPI.Repository.Services.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IRepository<Person> _repository;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();            
        }
               
        public Person FindById(long id)
        {            
            return _repository.FindById(id); ;
        }

        public Person Update(Person person)
        {
            return _repository.Update(person); ;
        }
    }
}
