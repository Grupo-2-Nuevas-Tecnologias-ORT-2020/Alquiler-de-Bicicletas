using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class AlquilerDeAccesorio
    {
        //This class will be deprecated

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Alquiler de Accesorio")]
        public int idAlquilerDeAccesorio { get; set; }

        [Display(Name = "ID Alquiler")]
        //Este atributo es una clave foránea a la tabla Alquiler
        public int idAlquiler { get; set; }

        [Display(Name = "ID Accesorio")]
        //Este atributo es una clave foránea a la tabla Accesorio
        public int idAccesorio { get; set; }
    }
}
