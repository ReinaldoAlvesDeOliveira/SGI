using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Enums
{
    public enum EEscolaridade
    {
        [Display(Name = "Ensino Fundamental Incompleto")]
        EnsinoFundamentalIncompleto = 1,
        [Display(Name = "Ensino Fundamental completo")]
        EnsinoFundamentalCompleto = 2,
        [Display(Name = "Ensino Medio Incompleto")]
        EnsinoNedioIncompleto = 3,
        [Display(Name = "Ensino Medio completo")]
        EnsinoMediolCompleto = 4,
        [Display(Name = "Ensino Superior Incompleto")]
        EnsinoSuperiorIncompleto = 5,
        [Display(Name = "Ensino Superior completo")]
        EnsinoSuperiorCompleto = 6,

    }
}
