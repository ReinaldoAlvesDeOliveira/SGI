using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Enums
{
    public enum EEstadoCivil
    {
        [Display(Name = "Casado")]
        Casado = 0,
        [Display(Name = "Solteiro")]
        Solterio = 1,
        [Display(Name ="Viúvo(a)")]
        Viuvo = 2,
    }
}
