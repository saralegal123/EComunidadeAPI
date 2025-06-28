using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using EComunidadeAPI.Models;
using System;

namespace EComunidadeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nome da tabela no banco
            modelBuilder.Entity<Evento>().ToTable("Eventos");

            // Chave primária
            modelBuilder.Entity<Evento>().HasKey(e => e.IdEvento);

            // Seed de dados (opcional, você pode mudar ou remover)
            modelBuilder.Entity<Evento>().HasData(
                new Evento
                {
                    IdEvento = 1,
                    TituloEvento = "Mutirão de Limpeza",
                    DescricaoEvento = "Evento para limpeza de praça local",
                    DataEvento = DateTime.Parse("2025-07-05"),
                    HoraEvento = "09:00",
                    QtVoluntarios = 10,
                    DuracaoEvento = 2,
                    PontuacaoEvento = 50,
                    LocalEvento = "Praça Central",
                    Situacao = Models.Enuns.SituacaoEnum.Inativo,
                    IdUsuario = 1
                },
                new Evento
                {
                    IdEvento = 2,
                    TituloEvento = "Doação de Agasalhos",
                    DescricaoEvento = "Campanha de arrecadação de roupas de inverno",
                    DataEvento = DateTime.Parse("2025-07-10"),
                    HoraEvento = "14:00",
                    QtVoluntarios = 5,
                    DuracaoEvento = 3,
                    PontuacaoEvento = 80,
                    LocalEvento = "Centro Comunitário",
                    Situacao = Models.Enuns.SituacaoEnum.Ativo,
                    IdUsuario = 2
                }
            );
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
