namespace Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public ICollection<UsuarioPerfil> UsuarioPerfis { get; set; }
    }
}
