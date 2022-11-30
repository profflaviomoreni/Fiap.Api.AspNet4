using Fiap.Api.AspNet4.Data;
using Fiap.Api.AspNet4.Models;
using Fiap.Api.AspNet4.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet4.Repository
{

    public class MarcaRepository : IMarcaRepository
    {
        private readonly DataContext _context;

        public MarcaRepository(DataContext context)
        {
            _context = context;
        }

        public IList<MarcaModel> FindAll()
        {
            return _context.Marcas.AsNoTracking().ToList();
        }



        public int Count()
        {
            return _context.Marcas.Count();
        }

        public IList<MarcaModel> FindAll(int pagina, int tamanho)
        {
            IList<MarcaModel> lista = _context.Marcas
                    .Skip(tamanho * pagina)
                    .Take(tamanho)
                    .ToList();

            return lista;
        }


        public MarcaModel FindById(int id)
        {
            return _context.Marcas.FirstOrDefault(x => x.MarcaId == id);
        }

        public int Insert(MarcaModel marcaModel)
        {
            _context.Marcas.Add(marcaModel);
            _context.SaveChanges();
            return marcaModel.MarcaId;
        }

        public void Update(MarcaModel marcaModel)
        {
            _context.Marcas.Update(marcaModel);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var marca = new MarcaModel()
            {
                MarcaId = id
            };

            _context.Marcas.Remove(marca);
            _context.SaveChanges();
        }

        
    }

}
