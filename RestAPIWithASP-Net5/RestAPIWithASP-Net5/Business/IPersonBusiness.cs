using System.Collections.Generic;
using RestAPIWithASP_Net5.Model;

namespace RestAPIWithASP_Net5.person.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
