using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Repository;
using RestAPI.Repository.Services;

namespace RestAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness _personService;

        public PersonController(IPersonBusiness personService)
        {
            _personService = personService;
        }


        // GET: api/Person
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null)
                return NotFound();
            else
                return Ok(person);
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null)
                return BadRequest();
            else
                return new ObjectResult(_personService.Create(person));
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        { 
            if (person == null)
                return BadRequest();
            else
                return new ObjectResult(_personService.Update(person));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
