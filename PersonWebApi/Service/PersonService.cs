using PersonWebApi.Interface;
using PersonWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebApi.Service
{
    public class PersonService : IPersonService
    {
        public List<Person> GetPerson()
        {
            return new List<Person>()
            {
                new Person
                {
                    GivenName="John",
                    FamilyName="Craw",
                    Age=20,
                    Address = "20 hampton street"
                },
                 new Person
                {
                    GivenName="Graham",
                    FamilyName="Smith",
                    Age=25,
                    Address = "25 New Way"
                },
            };
        }
    }
}
