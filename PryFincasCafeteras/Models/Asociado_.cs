using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PryFincasCafeteras.Models
{
    public class Asociado_
    {
        public int Id  { get; set; }

        [Required]
        [Display(Name = "Seleccione el parentesco con el propietario de la finca")]
        public string Parentesco { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Propietario")]
        public Nullable<int> Id_pariente { get; set; }
        public int IdFinca { get; set; }
        public String rol { get; set; }

    }
    [MetadataType(typeof(Asociado_))]
   partial class Asociado
    {
        [Required]
        [Display(Name = "Finca")]
        public int IdFinca { get; set; }
        public String rol { get; set; }
       
    }
}