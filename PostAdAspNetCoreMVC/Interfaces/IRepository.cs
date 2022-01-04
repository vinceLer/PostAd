using System.Collections.Generic;

namespace PostAdAspNetCoreMVC.Interfaces
{
    public interface IRepository<T>
    {
        T Save(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
