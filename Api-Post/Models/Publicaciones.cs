using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Post.Models
{
    public class Publicaciones
    {
        [Key]
        public int idPost { get; set; }
        [MaxLength(50)]
        public string nombrePost { get; set; }
        [MaxLength(200)]
        public string descripcion { get; set; }
        [ForeignKey("idUsuario")]
        public int idDeUsuario  { get; set; }
    }
}
