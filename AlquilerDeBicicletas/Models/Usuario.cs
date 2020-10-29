using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlquilerDeBicicletas.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String dni { get; set; }
        public String eMail { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public String contrasena { get; set; }
    }
}
