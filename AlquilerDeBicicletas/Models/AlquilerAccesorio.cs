using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class AlquilerAccesorio
    {
        //Tabla intermedia
        //Fuente: https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-entity-framework-core/
        //        https://entityframeworkcore.com/es/knowledge-base/46349747/-ef-----------------

        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Alquiler de Accesorio")]
        public int alquilerAccesorioID { get; set; }*/

        [Display(Name = "ID Alquiler")]
        public int alquilerID { get; set; }
        [Display(Name = "ID Accesorio")]
        public int accesorioID { get; set; }

        //Este atributo relaciona AlquilerAccesorio con Alquiler
        [Display(Name = "Alquiler")]
        public Alquiler alquiler { get; set; }
        //Este atributo relaciona AlquilerAccesorio con Accesorio
        [Display(Name = "Accesorio")]
        public Accesorio accesorio { get; set; }
    }
}
