using RestAPIWithASP_Net5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Repository.Repository
{
    public interface IRepository<T> where T : BaseEntity 
    {
        T Create(T item);
        T FindById(int id);
        Task<List<T>> FindAllAsync();
        T Update(T item);
        void Delete(int id);
    }
}
