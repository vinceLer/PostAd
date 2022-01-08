using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PostAdAspNetCoreMVC.Interfaces
{
    public interface IRepository<T>
    {
        T Save(T entity);
        T Get(int id);
        List<T> GetAll();
        List<T> Search(Expression<Func<T, bool>> searchMethode);
    }
}
