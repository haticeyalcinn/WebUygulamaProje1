using Microsoft.EntityFrameworkCore;
using WebUygulamaProje1.Models;

namespace WebUygulamaProje1.Utiliy
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext>options) : base(options) { }
        
        public DbSet<KitapTuru> KitapTurleri { get; set; }
    
    }
}
