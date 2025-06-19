using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using EComunidadeAPI.Data;


namespace EComunidadeAPI.Extensions
{
    public static class ClaimsExtensions
    {
       public static int GetUsuarioId(this ClaimsPrincipal user)
       {
           var valor = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
           return int.TryParse(valor, out int id) ? id : 0;
       }
       public static string GetUsuarioPerfil(this ClaimsPrincipal user)
       {
           return user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? string.Empty;
       }
    }
}