using Fiap.Api.AspNet4.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.AspNet4.Data
{
    public class DataContext : DbContext
    {

        public DbSet<MarcaModel> Marcas { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }



        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarcaModel>().HasData(
                new MarcaModel(1,"LG"),
                new MarcaModel(2,"Apple"),
                new MarcaModel(3,"Samsung"),
                new MarcaModel(4,"Motorola")
            );

            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel(1, "TV"),
                new CategoriaModel(2, "Smartphone"),
                new CategoriaModel(3, "PC"),
                new CategoriaModel(4, "Notebook")
            );

            modelBuilder.Entity<ProdutoModel>().HasData(
                new ProdutoModel(1, "iPhone 12 mini", "SKUIPH12", "Apple iPhone 12", 5000, "", DateTime.Now, 2, 2),
                new ProdutoModel(2, "iPhone 11", "SKUIPH11", "Apple iPhone 11", 11000, "", DateTime.Now, 2, 2),
                new ProdutoModel(3, "iPhone 12", "SKUIPH12", "Apple iPhone 12", 12000, "", DateTime.Now, 2, 2),
                new ProdutoModel(4, "iPhone 13", "SKUIPH13", "Apple iPhone 13", 13000, "", DateTime.Now, 2, 2)

            );

            modelBuilder.Entity<UsuarioModel>().HasData(
               new UsuarioModel(1, "Admin Senior", "123456", "Senior"),
               new UsuarioModel(2, "Admin Pleno", "123456", "Pleno"),
               new UsuarioModel(3, "Admin Junior", "123456", "Junior")
            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
