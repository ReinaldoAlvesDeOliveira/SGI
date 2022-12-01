namespace Domain.Models
{
    public class UsuarioPerfil
    {
        public int IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public Guid IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
