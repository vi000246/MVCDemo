using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace YDemo.Models
{
    public class FakeMovieRepository<TEntity> : IMovieRepository<TEntity>
        where TEntity : class,new()
    {
        private List<TEntity> data;

        //傳入一個測試用的list物件
        public FakeMovieRepository(List<TEntity> obj)
        {
            data = obj;
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }


        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Reads()
        {
            return data.AsQueryable();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IMovieRepository<TEntity>.Reads()
        {
            throw new NotImplementedException();
        }
    }
}