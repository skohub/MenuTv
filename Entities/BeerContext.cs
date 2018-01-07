using Microsoft.EntityFrameworkCore;

namespace MenuTv.Entities
{
    public class BeerContext : DbContext
    {
        public DbSet<Beer> Beers {get; set;}

        public BeerContext(DbContextOptions options) : base(options)
        {
        }
    }
}