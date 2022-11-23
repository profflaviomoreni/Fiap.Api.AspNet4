using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.AspNet4.Models
{
    [Table("Usuarios")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(30)]
        public string NomeUsuario { get; set; }

        [Required]
        [MaxLength(30)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(30)]
        public string Regra { get; set; }

        public UsuarioModel()
        {
        }

        public UsuarioModel(int usuarioId, string nomeUsuario, string senha, string regra)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Regra = regra;
        }



    }

}
