using backend_canella.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_canella.Contexts
{
    public class ConexionSQLServer:DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options){
        }

        public DbSet<Brands> Brands { get; set; }
        public DbSet<Agencies> Agencies { get; set; }
    }
}
