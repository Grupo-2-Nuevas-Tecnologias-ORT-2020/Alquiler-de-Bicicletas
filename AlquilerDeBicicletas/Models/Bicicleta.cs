using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlquilerDeBicicletas.Models
{
    public class Bicicleta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idBicicleta { get; set; }
        public TipoDeBici tipoDeBici { get; set; }
        public DateTime fechaDeIngreso { get; set; }
        public string color { get; set; }



    }
}
