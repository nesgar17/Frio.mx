
namespace Frio.mx.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class Torneo
    {

        [Key]
        public int TorneoId { get; set; }

        [Required(ErrorMessage = "EL campo {0} es obligatorio")]
        [StringLength(60, ErrorMessage = "El campo {0} debe tener minimo {1} y maximo {2} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        [Index("Torneo_Nombre_Index", IsUnique = true)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} puede contener como maximo {1} y minino {2} caracteres",
          MinimumLength = 3)]
        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Numero de Equipos")]
        public int NumeroEquipos { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Numero de Jornadas")]
        public int NumeroJornadas { get; set; }



        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        public virtual ICollection<Temporada> Temporadas { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }

    }
}