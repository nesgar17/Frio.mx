namespace Frio.mx.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class Equipo
    {

        [Key]
        public int EquipoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} puede contener como maximo {1} y minino {2} caracteres",
            MinimumLength = 3)]
        [Display(Name = "Nombre")]
        [Index("Equipo_Nombre_Index", IsUnique = true)]
        public string Nombre { get; set; }

        [Display(Name = "Escudo")]
        public string Escudo { get; set; }

        [NotMapped]
        public HttpPostedFileBase EscudoFile { get; set; }

        public int TorneoId { get; set; }

        public virtual Torneo Torneo { get; set; }
    }
}