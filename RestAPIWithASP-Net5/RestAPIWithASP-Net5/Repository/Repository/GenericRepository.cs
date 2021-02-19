using Microsoft.EntityFrameworkCore;
using RestAPIWithASP_Net5.Model.Base;
using RestAPIWithASP_Net5.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Repository.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MySqlContext Context;
        private DbSet<T> DataSet { get; set; }

        public GenericRepository(MySqlContext mySqlContext)
        {
            Context = mySqlContext;
            DataSet = Context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                if (item != null)
                {
                    DataSet.Add(item);
                    Context.SaveChanges();
                    return item;
                }
                else
                {
                    return null;
                }
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
                var result = DataSet.SingleOrDefaultAsync(p => p.Id == id);
                if (result != null)
                {
                    DataSet.Remove(result.Result);
                    Context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> FindAll()
        {
            try
            {
                return DataSet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public T FindById(int id)
        {
            try
            {
                var result = DataSet.FirstOrDefaultAsync(r => r.Id == id);
                return result.Result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public T Update(T item)
        {
            try
            {
                if (item != null)
                {
                    DataSet.Update(item);
                    Context.SaveChanges();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

     
    }
}
