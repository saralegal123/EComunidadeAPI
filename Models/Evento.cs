using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComunidadeAPI.Models.Enuns;

namespace EComunidadeAPI.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }

        public string TituloEvento  { get; set; }

        public string DescricaoEvento { get; set; }

        public string DataEvento { get; set; }

        public string HoraEvento { get; set;}

        public int QtVoluntarios { get; set; }

        public int DuracaoEvento { get; set; }

        public int PontuacaoEvento { get; set; }

        public string LocalEvento { get; set; }

        public SituacaoEnum Situacao { get; set;} 

    }
}