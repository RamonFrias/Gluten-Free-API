using GlutenFreeApi.Domains;
using Microsoft.EntityFrameworkCore;

namespace GlutenFreeApi.Context
{
    public class GlutenFreeApiContext : DbContext
    {
       public GlutenFreeApiContext(DbContextOptions<GlutenFreeApiContext> optins) : base(optins) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
