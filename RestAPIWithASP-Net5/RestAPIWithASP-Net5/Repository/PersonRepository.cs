using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Model.DataContext;
using RestAPIWithASP_Net5.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPIWithASP_Net5.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepository(MySqlContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!Context.Persons.Any(p => p.Id == id)) return null;
            var user = Context.Persons.FirstOrDefault(p => p.Id == id);
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    Context.Entry(user).CurrentValues.SetValues(user);
                    Context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (firstName == null && lastName == null) return null;
            try
            {
                if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                {
                    var result = Context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
                    if (result == null) return null;
                    return result;
                }
                else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                {
                    var result = Context.Persons.Where(p=>p.LastName.Contains(lastName)).ToList();
                    if (result == null) return null;
                    return result;
                }
                else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                {
                    var result = Context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
                    if (result == null) return null;
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
