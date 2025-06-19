using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComunidadeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EComunidadeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Evento> TB_EVENTOS { get; set; }
    }
}