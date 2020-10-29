using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //TODO 
        /*
         * idPago int
         * idAlquiler int
         * fechaDePago Date
         * monto double
         * formaDePago TIPO_DE_PAGO
         * esPagoBase boolean
         */
        public string BORRAR_ESTA_PROPIEDAD { get; set; }
    }
}
