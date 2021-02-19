using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPIWithASP_Net5.Repository.Repository;
using RestAPIWithASP_Net5.book.Business;

namespace RestAPIWithASP_Net5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IRepository<Book> Repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            Repository = repository;
        }

        public Book Create(Book book)
        {
            try
            {
                if (book != null)
                    return Repository.Create(book);
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Delete(int id)
        {
            try
            {
                Repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book FindById(int id)
        {
            try
            {
                var book = Repository.FindById(id);
                if (book != null)
                    return book;
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book Update(Book book)
        {
            return Repository.Update(book);
        }

        public IEnumerable<Book> FindAll()
        {
            return Repository.FindAll();
        }
    }
}
