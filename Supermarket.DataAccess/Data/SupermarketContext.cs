using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Models;

namespace Supermarket.DataAccess.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options)
            :base(options)
        {
            
        }

        public DbSet<User> User { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<GoodsType> GoodsType { get; set; }

        public DbSet<Sell> Sell { get; set; }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<StockPrice> StockPrice { get; set; }
    }
}