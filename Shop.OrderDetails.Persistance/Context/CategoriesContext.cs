
using Shop.Categories.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shop.Categories.Persistence.Context
{
    public class ShopContext : DbContext
    {
        // Constructor que recibe opciones de configuración del DbContext
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        // DbSet para cada entidad del modelo de datos
        public DbSet<Domain.Entities.Categories> Categories { get; set; }
    }
}
