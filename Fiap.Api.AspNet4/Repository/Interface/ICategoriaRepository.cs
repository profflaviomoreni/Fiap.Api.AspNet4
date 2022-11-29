using Fiap.Api.AspNet4.Models;

namespace Fiap.Api.AspNet4.Repository.Interface
{
    public interface ICategoriaRepository
    {
        public IList<CategoriaModel> FindAll();
        public CategoriaModel FindById(int id);
        public int Insert(CategoriaModel categoriaModel);
        public void Delete(int id);
        public void Update(CategoriaModel categoriaModel);

    }
}
