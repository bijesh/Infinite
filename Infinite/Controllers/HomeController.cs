using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infinite.Interface;
using Infinite.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infinite.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPersonViewModelBuilder _personViewModelBuilder;

        public HomeController(IPersonService personService, IPersonViewModelBuilder personViewModelBuilder)
        {
            _personService = personService;
            _personViewModelBuilder = personViewModelBuilder;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<PersonViewModel>> Get()
        {
            var personList = await _personService.GetPerson();
            var personViewModelList =  personList.Select(p => _personViewModelBuilder.Build(p));
            return personViewModelList;
        }
       
    }
}
