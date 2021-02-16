using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly MySqlContext _context;

        public BookRepositoryImplementation(MySqlContext mySqlContext)
        {
            _context = mySqlContext;
        }

        public Book Create(Book book)
        {
            try
            {
                if (book != null)
                {
                    _context.Books.Add(book);
                    _context.SaveChanges();

                    return book;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var book = _context.Books.FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Book> FindAll()
        {
            try
            {
                return _context.Books.ToList();
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
                Book book = _context.Books.Find(id);
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
            try
            {
                if (book != null)
                {
                    _context.Books.Update(book);
                    _context.SaveChanges();
                    return book;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
