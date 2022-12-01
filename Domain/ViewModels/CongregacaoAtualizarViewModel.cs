using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class CongregacaoAtualizarViewModel
    {
        [Required]
        public string NomeCongregacao { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
