using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPIWithASP_Net5.Model;

namespace RestAPIWithASP_Net5.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
