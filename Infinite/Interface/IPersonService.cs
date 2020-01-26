using Infinite.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinite.Interface
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPerson();
    }
}
