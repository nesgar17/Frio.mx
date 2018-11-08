namespace Frio.mx.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class Temporada
    {

        [Key]
        public int TemporadaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} puede contener como maximo {1} y minino {2} caracteres",
           MinimumLength = 3)]
        [Display(Name = "Nombre")]
        [Index("Temporada_Nombre_Index", IsUnique = true)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Inicia")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Termina")]
        [DataType(DataType.Date)]
        public DateTime FechaTermino { get; set; }

        public int TorneoId { get; set; }

        public virtual Torneo Torneo { get; set; }

        public virtual ICollection<Jornada> Jornadas { get; set; }

    }
}