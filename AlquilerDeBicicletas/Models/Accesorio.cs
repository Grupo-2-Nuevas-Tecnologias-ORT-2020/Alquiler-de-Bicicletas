using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class Accesorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAccesorio { get; set; }
        public TipoDeAccesorio tipoDeAccesorio { get; set; }
        public DateTime fechaDeIngreso { get; set; }
        public string color { get; set; }
    }
}
