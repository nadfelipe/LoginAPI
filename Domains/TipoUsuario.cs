using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_webAPI.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage ="O nome do tipo usuário é orbigatório.")]
        public string Nome { get; set; }
    }
}
