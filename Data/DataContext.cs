using EComunidadeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace EComunidadeAPI.Data
{
   public class DataContext : DbContext
   {
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       public DbSet<Evento> Eventos { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {

           modelBuilder.Entity<Evento>().ToTable("Eventos");
           modelBuilder.Entity<Evento>().HasKey(e => e.IdEvento);

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