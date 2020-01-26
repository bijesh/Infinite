using PersonWebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonWebApi.Model;

namespace PersonWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
           return _personService.GetPerson();
        }
    }
}
