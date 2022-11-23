using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.AspNet4.Models
{
    [Table("Categorias")]
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string NomeCategoria { get; set; }

        public CategoriaModel()
        {
        }

        public CategoriaModel(int categoriaId, string nomeCategoria)
        {
            CategoriaId = categoriaId;
            NomeCategoria = nomeCategoria;
        }


    }
}
