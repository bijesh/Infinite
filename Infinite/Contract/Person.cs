using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Infinite.Contract
{
    [ExcludeFromCodeCoverage]
    public class Person
    {
        [JsonProperty("givenName")]
        public string GivenName { get; set; }
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
