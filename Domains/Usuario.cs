using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_webAPI.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "O Nome do usuário é obrigatório.")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "O E-mail do usuário é obrigatório.")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(max)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        public string Senha { get; set; }

        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
