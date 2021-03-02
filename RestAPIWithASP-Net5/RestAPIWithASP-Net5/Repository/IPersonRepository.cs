using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Repository.Repository;
using System.Collections.Generic;

namespace RestAPIWithASP_Net5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
