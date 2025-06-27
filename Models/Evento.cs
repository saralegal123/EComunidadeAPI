using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComunidadeAPI.Models.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
 
namespace EComunidadeAPI.Models
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
 
        public string? TituloEvento  { get; set; }
 
        public string? DescricaoEvento { get; set; }
 
        public DateTime? DataEvento { get; set; }

        public string? HoraEvento { get; set;}
 
        public int QtVoluntarios { get; set; }
 
        public int DuracaoEvento { get; set; }
 
        public int PontuacaoEvento { get; set; }
 
        public string? LocalEvento { get; set; }
 
        public SituacaoEnum Situacao { get; set;}
 
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
    }
}