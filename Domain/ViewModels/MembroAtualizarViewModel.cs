using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class MembroAtualizarViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string DataNascimento { get; set; }
        [Required]
        public string Whattsapp { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Pai { get; set; }
        [Required]
        public string Mae { get; set; }
        public string? DataBatismoAgua { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
