using Microsoft.EntityFrameworkCore;

namespace backEnd.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }

    }
}
