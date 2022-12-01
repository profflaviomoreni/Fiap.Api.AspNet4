using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Fiap.Api.AspNet4.Models
{
    public class CursoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("preco")]
        public double Preco { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("nivel")]
        public string Nivel { get; set; }

        [JsonProperty("conteudo")]
        public string Conteudo { get; set; }

        [JsonProperty("concluido")]
        public bool Concluido { get; set; }

        [JsonProperty("percentualConclusao")]
        public double PercentualConclusao { get; set; }

    }
}
