using Fiap.Api.AspNet4.Data;
using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet4.Repository
{

    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public IList<CategoriaModel> FindAll()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        public CategoriaModel FindById(int id)
        {
            return _context.Categorias.FirstOrDefault(x => x.CategoriaId == id);
        }

        public int Insert(CategoriaModel categoriaModel)
        {
            _context.Categorias.Add(categoriaModel);
            _context.SaveChanges();
            return categoriaModel.CategoriaId;
        }

        public void Update(CategoriaModel categoriaModel)
        {
            _context.Categorias.Update(categoriaModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoria = new CategoriaModel()
            {
                CategoriaId = id
            };

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
    }


}
