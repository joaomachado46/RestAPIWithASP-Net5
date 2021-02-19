using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.person.Business;
using RestAPIWithASP_Net5.Repository;
using RestAPIWithASP_Net5.Repository.Repository;
using System;
using System.Collections.Generic;

namespace RestAPIWithASP_Net5.Business.Implementations
{
    public class IPersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _personRepository;
        //CONSTRUTOR
        public IPersonBusinessImplementation(IRepository<Person> personRepository)
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
    }
}
