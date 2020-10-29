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
        public int idPago{ get; set; }
        public int idAlquiler { get; set; }
        public DateTime fechaDePago{ get; set; }
        public double monto{ get; set; }
        public TIPO_DE_PAGO formaDePago { get; set; }
        public Boolean esPagoBase { get; set; }

    }
}
