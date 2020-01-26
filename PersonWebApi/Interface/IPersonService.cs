using PersonWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebApi.Interface
{
   public interface IPersonService
    {
        List<Person> GetPerson();
    }
}
