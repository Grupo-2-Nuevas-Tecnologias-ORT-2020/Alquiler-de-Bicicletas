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

        //Estos atributos relacionan Accesorio con TipoDeAccesorio
        [Display(Name = "Tipo de Accesorio ID")]
        public Nullable<int> tipoDeAccesorioID { get; set; }

        [Display(Name = "Tipo de Accesorio")]
        public virtual TipoDeAccesorio tipoDeAccesorio { get; set; }

        //Estos atributos relacionan Alquiler con Accesorio
        [JsonIgnore]
        public virtual ICollection<AlquilerAccesorio> alquileresAccesorio { get; } = new HashSet<AlquilerAccesorio>();
        [NotMapped]
        public IList<Alquiler> alquileres => alquileresAccesorio.Select(alac => alac.alquiler).ToList();

    }
}
