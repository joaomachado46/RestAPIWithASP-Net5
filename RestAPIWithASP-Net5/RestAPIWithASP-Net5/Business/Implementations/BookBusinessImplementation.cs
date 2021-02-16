using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPIWithASP_Net5.book.Business;

namespace RestAPIWithASP_Net5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IBookRepository _bookRepository;

        public BookBusinessImplementation(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Create(Book book)
        {
            try
            {
                if (book != null)
                    return _bookRepository.Create(book);
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
                _bookRepository.Delete(id);
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
                var book = _bookRepository.FindById(id);
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
            return _bookRepository.Update(book);
        }

        public IEnumerable<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }
    }
}
