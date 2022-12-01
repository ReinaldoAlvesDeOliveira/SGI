using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class EnderecoViewModel
    {
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cep { get; set; }
    }
}
