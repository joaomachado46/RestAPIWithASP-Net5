using System.Collections.Generic;
using RestAPIWithASP_Net5.Model;
using RestWithASPNETUdemy.Hypermedia.Utils;

namespace RestAPIWithASP_Net5.person.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        List<Person> FindByName(string firstName, string lastName);
        Person Update(Person person);
        void Delete(int id);
        Person Disable(long id);

        PagedSearchVO<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
