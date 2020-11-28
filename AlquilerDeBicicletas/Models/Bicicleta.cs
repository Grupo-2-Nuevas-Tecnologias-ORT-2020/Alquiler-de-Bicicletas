using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class Bicicleta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Bicicleta")]
        public int bicicletaID { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime fechaDeIngreso { get; set; }

        [Display(Name = "Color")]
        public string color { get; set; }

        //Estos atributos relacionan Bicicleta con TipoDeBici
        [Display(Name = "ID Tipo de Bicicleta")]
        public Nullable<int> tipoDeBiciID { get; set; }

        [Display(Name = "Tipo de Bicicleta")]
        public virtual TipoDeBici tipoDeBici { get; set; }

        //Este atributo relaciona Bicicleta con Alquiler
        [Display(Name = "Alquileres")]
        public virtual ICollection<Alquiler> alquileres { get; set; }
    }
}
