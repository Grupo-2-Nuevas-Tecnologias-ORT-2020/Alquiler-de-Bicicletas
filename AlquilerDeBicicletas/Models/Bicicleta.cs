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


        [Display(Name = "Tipo de Bicicleta")]
        //Este atributo es una clave foránea a la tabla TipoDeBici
        public int tipoDeBiciID { get; set; }

        public TipoDeBici tipoDeBici { get; set; }
    }
}
