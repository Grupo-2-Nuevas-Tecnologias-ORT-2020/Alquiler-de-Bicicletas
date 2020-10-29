using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AlquilerDeBicicletas.Models
{
    public class TipoDeAccesorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoDeAccesorio { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
    }
}
