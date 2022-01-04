using PostAdAspNetCoreMVC.Tools;

namespace PostAdAspNetCoreMVC.Repositories
{
    public class BaseRepository
    {
        protected DataContext _dataContext;

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
