using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlquilerDeBicicletas.Models
{
    public class Alquiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Alquiler")]
        public int idAlquiler { get; set; }

        //Este atributo es una clave foránea a la tabla Usuario
        [Display(Name = "ID Usuario")]
        public int idUsuario { get; set; }

        //Este atributo es una clave foránea a la tabla Bicicleta
        [Display(Name = "ID Bicicleta")]
        public int idBicicleta { get; set; }

        [Display(Name = "Estado del Alquiler")]
        public ESTADO_BICICLETA estadoAlquiler { get; set; }

        [Display(Name = "Inicio de Alquiler")]
        public DateTime fechaDesde { get; set; }

        [Display(Name = "Fin de Alquiler")]
        public DateTime fechaHasta { get; set; }

        [Display(Name = "La fecha cambió")]
        public bool cambioFecha { get; set; }
        
        [Display(Name = "Horas estipuladas")]
        public int horasBase { get; set; }

        [Display(Name = "Fecha de Entrega Final")]
        public DateTime fechaEntregaFinal { get; set; }

        [Display(Name = "Horas extras")]
        public int horasExtras { get; set; }
        
        [Display(Name = "Total a pagar estipulado")]
        public double totalAPagarBase { get; set; }

        [Display(Name = "Total a pagar extras")]
        public double totalAPagarExtra { get; set; }
    }
}
