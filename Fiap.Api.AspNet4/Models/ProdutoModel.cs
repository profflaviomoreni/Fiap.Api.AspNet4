using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Fiap.Api.AspNet4.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(2)]
        public string Sku { get; set; }

        [Required]
        [MaxLength(300)]
        [MinLength(5)]
        public string Descricao { get; set; }

        [Required]
        public Decimal Preco { get; set; }

        [MaxLength(3000)]
        public string Caracteristicas { get; set; }

        public DateTime DataLancamento { get; set; }


        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]

        [AllowNull]
        public CategoriaModel Categoria { get; set; }


        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]

        [AllowNull]
        public MarcaModel Marca { get; set; }


        public ProdutoModel()
        {
        }

        public ProdutoModel(int ProdutoId, String Nome)
        {
            this.ProdutoId = ProdutoId;
            this.Nome = Nome;
        }

        public ProdutoModel(int produtoId, string nome, string sku, string descricao, decimal preco, string caracteristicas, DateTime dataLancamento, int categoriaId, int marcaId) : this(produtoId, nome)
        {
            Sku = sku;
            Descricao = descricao;
            Preco = preco;
            Caracteristicas = caracteristicas;
            DataLancamento = dataLancamento;
            CategoriaId = categoriaId;
            MarcaId = marcaId;
        }

    }
}
