using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Enums
{
    public enum EGenero
    {
        [Display(Name = "Feminino")]
        Feminino = 1,
        [Display(Name = "Masculino")]
        Masculino = 2,
    }
}
