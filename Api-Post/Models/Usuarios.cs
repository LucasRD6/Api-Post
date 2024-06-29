using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Post.Models
{
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }
        [MaxLength(50)]
        public string nombreUsuario { get; set; }
    }
}
