using Microsoft.EntityFrameworkCore;
using PostAdAspNetCoreMVC.Interfaces;
using PostAdAspNetCoreMVC.Models;
using PostAdAspNetCoreMVC.Tools;
using System.Collections.Generic;
using System.Linq;

namespace PostAdAspNetCoreMVC.Repositories
{
    public class AdRepository : BaseRepository, IRepository<Ad>
    {
        public AdRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Ad Get(int id)
        {
            return _dataContext.Ads.Include(a => a.Images).FirstOrDefault(a => a.Id == id);
        }

        public List<Ad> GetAll()
        {
            return _dataContext.Ads.Include(a => a.Images).ToList(); ;
        }

        public Ad Save(Ad entity)
        {
            _dataContext.Ads.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
    }
}
