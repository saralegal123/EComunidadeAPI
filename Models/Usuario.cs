using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComunidadeAPI.Models.Enuns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EComunidadeAPI.Models
{
    public class Usuario
    {
       [Key]
       public int Id { get; set; }
       [Required]
       public string Nome { get; set; } = string.Empty;
       [Required]
       public string Email { get; set; } = string.Empty;
       [Required]
       public string Senha { get; set; } = string.Empty;

       [Required]
       public string CEP { get; set; } = string.Empty;

       [Required]
       public string Telefone { get; set; } = string.Empty;

       [NotMapped]
       public string? Token { get; set; }
    }
}