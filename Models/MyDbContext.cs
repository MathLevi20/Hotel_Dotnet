using Microsoft.EntityFrameworkCore;

namespace hotel.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Fisica> Fisica { get; set; }
        public DbSet<Juridica> Juridica { get; set; }
        public DbSet<Parceiro> Parceiro { get; set; }
        public DbSet<ReservaHotel> ReservaHotel { get; set; }

    }

}
