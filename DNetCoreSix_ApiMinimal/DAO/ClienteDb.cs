using DNetCoreSix_ApiMinimal.Model;
using Microsoft.EntityFrameworkCore;

namespace DNetCoreSix_ApiMinimal.DAO
{
    public class ClienteDb: DbContext {
        public ClienteDb(DbContextOptions<ClienteDb> options): base(options) {}
        public DbSet<Cliente> cliente => Set<Cliente>();
    }

}