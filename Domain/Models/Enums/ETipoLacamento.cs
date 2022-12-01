using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Enums
{
    public enum ETipoLacamento
    {
        [Display(Name ="Entrada")]
        Entrada = 1,
        [Display(Name = "Saída")]
        Saida = 2,
    }
}
