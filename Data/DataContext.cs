using EComunidadeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace EComunidadeAPI.Data
{
   public class DataContext : DbContext
   {
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       public DbSet<Evento> Eventos { get; set; }
       public DbSet<Usuario> Usuario { get; set; } 
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {

           modelBuilder.Entity<Evento>().ToTable("Eventos");
           modelBuilder.Entity<Evento>().HasKey(e => e.IdEvento);

           modelBuilder.Entity<Usuario>().ToTable("Usuario");
           modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
       }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           if (!optionsBuilder.IsConfigured)
           {
               optionsBuilder.ConfigureWarnings(warnings =>
                   warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
           }
       }
   }
}