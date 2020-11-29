using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlquilerDeBicicletas.Security;

namespace AlquilerDeBicicletas.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Usuario")]
        public int usuarioID { get; set; }

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

        //Va a guardar la contraseña encriptada
        [Display(Name = "Contraseña")]
        public String contrasena {
            get { return contrasena; }
            set { contrasena = Encryption.Encrypt(value); }
        }

        //Este atributo relaciona Usuario con Alquiler
        [Display(Name = "Alquileres")]
        public virtual ICollection<Alquiler> alquileres { get; set; }

        /*
        string text = "asd";
        string EncryptionCode = Encryption.Encrypt(text);
        string DecryptCode = Encryption.Decrypt(EncryptionCode);

        Console.WriteLine("Texto plano: " + text);
            Console.WriteLine("Texto encriptado: " + EncryptionCode);
            Console.WriteLine("Texto tesencriptado: " + DecryptCode);

            if (text == DecryptCode)
            {
                Console.WriteLine("dale boca");

            }
            else
            {
                Console.WriteLine("Nuestros padres son primos");
            }
*/

        /* No usamos esto
        // the mapped-to-column property 
        protected virtual string PasswordStored
        {
            get;
            set;
        }

        [NotMapped]
        public string Password
        {
            get { return Decrypt(PasswordStored); }
            set { PasswordStored = Encrypt(value); }
        }*/


    }
}
