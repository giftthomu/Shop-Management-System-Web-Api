using CRUD_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WEB_API.Data
{
    public class CrudWebApiContext:DbContext
    {
        public CrudWebApiContext(DbContextOptions<CrudWebApiContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
    }
}
