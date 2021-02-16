using RestAPIWithASP_Net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> FindAll();
        public Book FindById(int id);
        public Book Create(Book book);
        public Book Update(Book book);
        public void Delete(int id);
    }
}
