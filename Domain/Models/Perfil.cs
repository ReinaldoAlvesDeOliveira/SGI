using Domain.Models.Enums;
using SGI.Helper;

namespace Domain.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public ETipoPerfil TipoPerfil { get; set; }
        public ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }

        public string TipoPerfilFormat => TipoPerfil.GetDisplayName();
    }
}
