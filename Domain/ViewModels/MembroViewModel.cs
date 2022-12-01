using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class MembroViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string DataNascimento { get; set; }
        [Required]
        public string Whatsapp { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Pai { get; set; }
        [Required]
        public string Mae { get; set; }
        public string? DataBatismoAgua { get; set; }
        public EGenero Genero { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public int? IdMatriz { get; set; }
        public int? IdCongregracao { get; set; }

    }
}
