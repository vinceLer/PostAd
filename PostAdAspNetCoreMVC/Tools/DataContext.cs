using Microsoft.EntityFrameworkCore;
using PostAdAspNetCoreMVC.Models;

namespace PostAdAspNetCoreMVC.Tools
{
    public class DataContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v-app;Integrated Security=True");
        }
    }
}
