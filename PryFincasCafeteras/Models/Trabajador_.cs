using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PryFincasCafeteras.Models
{
    public class Trabajador_
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Periodo del contrato")]
        public string PeriodoContrato { get; set; }
        [Required]
        [Display(Name = "Finca")]
        public Nullable<int> IdFinca { get; set; }
    }
    [MetadataType(typeof(Trabajador_))]
    partial class Trabajador
    {
    }
    }