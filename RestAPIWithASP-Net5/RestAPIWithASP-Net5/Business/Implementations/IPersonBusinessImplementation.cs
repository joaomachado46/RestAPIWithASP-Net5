using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.person.Business;
using RestAPIWithASP_Net5.Repository;
using RestWithASPNETUdemy.Hypermedia.Utils;
using System;
using System.Collections.Generic;

namespace RestAPIWithASP_Net5.Business.Implementations
{
    public class IPersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _personRepository;
        //CONSTRUTOR
        public IPersonBusinessImplementation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        //LISTA DE PESSOAS
        public List<Person> FindAll()
        {
            try
            {
                return _personRepository.FindAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
        //ENCONTRAR POR ID
        public Person FindById(int id)
        {
            try
            {
                return _personRepository.FindById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            try
            {
                var result = _personRepository.FindByName(firstName, lastName);
                if (result == null) return null;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //POST = CRIAR UMA NOVA PESSOA
        public Person Create(Person person)
        {
            try
            {
                return _personRepository.Create(person);
                ;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //FAZER UPDATE DE DADOS DA PESSOA
        public Person Update(Person person)
        {
            try
            {
                if (person != null)
                {
                    return _personRepository.Update(person);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Person Disable(long id)
        {
            var result = _personRepository.Disable(id);
            if (result == null) return null;
            return result;
        }

        //APAGAR UMA PESSOA DA BD
        public void Delete(int id)
        {
            try
            {
                _personRepository.Delete(id);
            }
            catch (Exception)
            {
            }
        }

        public PagedSearchVO<Person> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offSet = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from person p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $" and p.first_name like '%{name}%' ";
            query += $" order by p.first_name {sort} limit {size} offset {offSet}";

            string countQuery = @"select count(*) from person p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $" and p.first_name like '%{name}%' ";

            var persons = _personRepository.FindWithPageSearch(query);
            int totalResults = _personRepository.GetCount(countQuery);

            return new PagedSearchVO<Person>
            {
                CurrentPage = page,
                List = persons,
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }
    }
}
