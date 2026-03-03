using Microsoft.EntityFrameworkCore;
using CuentaBancaria.Models;

namespace CuentaBancaria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Datos_Cuenta> CuentasBancarias { get; set; }
    }
}
