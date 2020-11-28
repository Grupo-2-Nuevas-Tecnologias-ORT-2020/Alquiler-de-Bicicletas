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
        [Display(Name = "ID Pago")]
        public int pagoID { get; set; }


        [Display(Name = "Fecha de Pago")]
        public DateTime fechaDePago{ get; set; }

        [Display(Name = "Monto")]
        public double monto{ get; set; }

        [Display(Name = "Forma de pago")]
        public TIPO_DE_PAGO formaDePago { get; set; }

        [Display(Name = "Es pago base")]
        public bool esPagoBase { get; set; }



        //Este atributo es una clave foránea a la tabla Alquiler
        [Display(Name = "Alquiler")]
        public int alquiler { get; set; }
    }
}
