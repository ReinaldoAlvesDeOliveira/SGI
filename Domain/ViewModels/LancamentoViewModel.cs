using Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class LancamentoViewModel
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public ETipoLacamento TipoLacamento { get; set; }
        public int? IdMatriz { get; set; } 
        public int? IdCongregracao { get; set; } 
        public int? IdMenbro { get; set; }                                             

    }
}
