using Infinite.Contract;
using Infinite.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infinite.Services
{
    public class PersonService : IPersonService
    {
        private readonly IWebApiClient _webApiClient;
        private readonly IConfiguration _configuration;
        public PersonService(IWebApiClient webApiClient, IConfiguration configuration)
        {
            _webApiClient = webApiClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Person>> GetPerson()
        {
            var personUrl = _configuration.GetSection("PersonApi");
            var httpEndpoint = personUrl["http"];
            var response = await _webApiClient.GetAsync(httpEndpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var personList = JsonConvert.DeserializeObject<List<Person>>(apiResponse);
            return personList;
        }
    }
}
