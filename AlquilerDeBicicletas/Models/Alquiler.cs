using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;

using Newtonsoft.Json.Serialization;
using System.Reflection;



namespace AlquilerDeBicicletas.Models
{
    public class Alquiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Alquiler")]
        public int alquilerID { get; set; }

        [Display(Name = "Estado del Alquiler")]
        [EnumDataType(typeof(ESTADO_ALQUILER))]
        public ESTADO_ALQUILER estadoAlquiler { get; set; }

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

        //Estos atributos relacionan Alquiler con Usuario
        [Display(Name = "ID Usuario")]
        public Nullable<int> usuarioID { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario usuario { get; set; }

        //Estos atributos relacionan Alquiler con Bicicleta
        [Display(Name = "ID Bicicleta")]
        public Nullable<int> bicicletaID { get; set; }

        [Display(Name = "Bicicleta")]
        public virtual Bicicleta bicicleta { get; set; }

        //Este atributo relaciona Alquiler con Pago
        [Display(Name = "Pagos")]
        public virtual ICollection<Pago> pagos { get; set; }

        
        //Estos atributos relacionan Alquiler con Accesorio
        [JsonIgnore]
        public virtual ICollection<AlquilerAccesorio> accesoriosAlquiler { get; } = new HashSet<AlquilerAccesorio>();
        [NotMapped]
        public IList<Accesorio> accesorios => accesoriosAlquiler.Select(alac => alac.accesorio).ToList();
         
         
    }
}
