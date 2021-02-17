using RestAPIWithASP_Net5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.book.Business
{
    public interface IBookBusiness
    {
        public Task<IEnumerable<Book>> FindAllAsync();
        public Book FindById(int id);
        public Book Create(Book book);
        public Book Update(Book book);
        public void Delete(int id);

    }
}
