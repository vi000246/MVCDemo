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
        public List<TEntity> data;

        //傳入一個測試用的list物件
        public FakeMovieRepository(List<TEntity> obj)
        {
            data = obj;
        }

        public void Create(TEntity entity)
        {
            data.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            data.Remove(entity);
        }


        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
        {
            return data.AsQueryable<TEntity>().Where(predicate).FirstOrDefault();
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

        public void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties)
        {
            throw new NotImplementedException();
        }

        IQueryable<TEntity> IMovieRepository<TEntity>.Reads()
        {
            return data.AsQueryable();
        }
    }
}