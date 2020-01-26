using Infinite.Contract;
using Infinite.Interface;
using Infinite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinite.ViewModelBuilder
{
    public class PersonViewModelBuilder : IPersonViewModelBuilder
    {
        public PersonViewModel Build(Person person)
        {
            return new PersonViewModel
            {
                FirstName = person.GivenName,
                LastName = person.FamilyName
            };
        }
    }
}
