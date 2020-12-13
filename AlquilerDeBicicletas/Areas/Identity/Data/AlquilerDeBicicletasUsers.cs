using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AlquilerDeBicicletas.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AlquilerDeBicicletasUsers class
    public class AlquilerDeBicicletasUsers : IdentityUser
    {
        [PersonalData]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }

        [PersonalData]
        [Display(Name = "Apellido")]
        public String apellido { get; set; }

        [PersonalData]
        [Display(Name = "DNI")]
        public String dni { get; set; }

        [PersonalData]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaNacimiento { get; set; }

        //Va a guardar la contraseña encriptada
        [Display(Name = "Contraseña")]
        [PersonalData]
        [DataType(DataType.Password)]
        public String contrasena { get; set; }
    }
}
