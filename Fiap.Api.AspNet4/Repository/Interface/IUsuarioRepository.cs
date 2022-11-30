using Fiap.Api.AspNet4.Models;

namespace Fiap.Api.AspNet4.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public IList<UsuarioModel> FindAll();
        public UsuarioModel FindById(int id);
        public UsuarioModel FindByName(string name);

        public UsuarioModel FindByNameAndSenha(string name, string senha);
        public int Insert(UsuarioModel usuarioModel);
        public void Delete(int id);
        public void Update(UsuarioModel usuarioModel);
    }
}
