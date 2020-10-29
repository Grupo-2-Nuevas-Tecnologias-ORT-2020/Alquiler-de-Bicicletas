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
    }
}
