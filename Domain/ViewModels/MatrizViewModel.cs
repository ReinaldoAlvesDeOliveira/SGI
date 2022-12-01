using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class MatrizViewModel
    {
        [Required]
        public string NomeMatriz { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
