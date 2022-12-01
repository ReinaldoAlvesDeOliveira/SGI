using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Enums
{
    public enum ETipoPerfil
    {
        [Display(Name = "Administrador")]
        Administrador = 1,
        [Display(Name = "Supervisor")]
        Supervisor = 2,
        [Display(Name = "Dirigente")]
        Dirigente = 3,
        [Display(Name = "Membro")]
        Membro = 4,
    }
}
