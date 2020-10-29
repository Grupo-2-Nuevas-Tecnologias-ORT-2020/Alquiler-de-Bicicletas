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
        //TODO
        /*
         * 
         */
        public int idAlquiler { get; set; }
        public int idUsuario { get; set; }
        public int idBicicleta { get; set; }
        public ESTADO_BICICLETA estadoAlquiler { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public Boolean cambioFecha { get; set; }
        public int horasBase { get; set; }
        public DateTime fechaEntregaFinal { get; set; }
        public int horasExtras { get; set; }
        public double totalAPagarBase { get; set; }
        public double totalAPagarExtra { get; set; }
    }
}
