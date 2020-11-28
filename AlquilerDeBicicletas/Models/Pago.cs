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
        [EnumDataType(typeof(TIPO_DE_PAGO))]
        public TIPO_DE_PAGO formaDePago { get; set; }

        [Display(Name = "Es pago base")]
        public bool esPagoBase { get; set; }

        //Estos atributos relacionan Pago con Alquiler
        [Display(Name = "ID Alquiler")]
        public Nullable<int> alquilerID { get; set; }

        [Display(Name = "Alquiler")]
        public virtual Alquiler alquiler { get; set; }
    }
}
