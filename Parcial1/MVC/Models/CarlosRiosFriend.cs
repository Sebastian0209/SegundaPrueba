using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public enum Type
    {
        Conocido,
        CompañeroDeEstudio,
        ColegaDeTrabajo,
        Amigo,
        AmigoDeInfancia,
        Pariente

    }



    public class CarlosRiosFriend
    {
        [Key]
        public int Llave { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public string TipoAmigo { get; set; }

        public string Apodo { get; set; }

        public DateTime Cumpleaños { get; set; }


    }
}