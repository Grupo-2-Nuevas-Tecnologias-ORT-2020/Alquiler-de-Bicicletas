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
        [Display(Name = "ID Usuario")]
        public int idUsuario { get; set; }

        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        [Display(Name = "Apellido")]
        public String apellido { get; set; }

        [Display(Name = "DNI")]
        public String dni { get; set; }

        [Display(Name = "E-Mail")]
        public String eMail { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Contraseña")]
        public String contrasena { get; set; }
    }
}
