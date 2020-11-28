using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class Accesorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Accesorio")]
        public int accesorioID { get; set; }

        [Display(Name = "Fecha de Ingreso")] 
        public DateTime fechaDeIngreso { get; set; }

        [Display(Name = "Color")]
        public string color { get; set; }



        [Display(Name = "Tipo de Accesorio")]
        //Este atributo es una clave foránea a la tabla TipoDeAccesorio
        public int tipoDeAccesorio { get; set; }
    }
}
