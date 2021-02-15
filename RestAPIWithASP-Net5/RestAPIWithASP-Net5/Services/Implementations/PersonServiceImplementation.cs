using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly MySqlContext _context;
        //CONSTRUTOR
        public PersonServiceImplementation(MySqlContext mySqlContext)
        {
            _context = mySqlContext;
        }

        //LISTA DE PESSOAS
        public List<Person> FindAll()
        {
            try
            {
                return _context.Persons.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        //ENCONTRAR POR ID
        public Person FindById(long id)
        {
            try
            {
                return _context.Persons.FirstOrDefault(pId => pId.Id == id);
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
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;
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
                    _context.Update(person);
                    _context.SaveChanges();

                    return person;
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
        public void Delete(long id)
        {
            try
            {
                var person = _context.Persons.FirstOrDefault(p => p.Id == id);

                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}
