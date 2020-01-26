using Infinite.Contract;
using Infinite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infinite.Interface
{
    public interface IPersonViewModelBuilder
    {
       PersonViewModel Build(Person person);
    }
}
