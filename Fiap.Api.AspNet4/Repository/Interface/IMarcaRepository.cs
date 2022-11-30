using Fiap.Api.AspNet4.Models;

namespace Fiap.Api.AspNet4.Repository.Interface
{
    public interface IMarcaRepository
    {
        public IList<MarcaModel> FindAll();
        public int Count();
        public IList<MarcaModel> FindAll(int pagina, int tamanho);
        public MarcaModel FindById(int id);
        public int Insert(MarcaModel marcaModel);
        public void Delete(int id);
        public void Update(MarcaModel marcaModel);
    }
}
