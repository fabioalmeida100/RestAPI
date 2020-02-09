using RestAPI.Repository.Context;
using RestAPI.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPI.Repository.Implementation
{
    public class PersonRepositoryImpl : GenericRepository<Person>
    {
        public PersonRepositoryImpl(MySQLContext context) : base(context)
        {

        }
    }
}
