using Api_Entity_Relations.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Entity_Relations.Context
{
    public class PrincipalContext : DbContext
    {
        public PrincipalContext(DbContextOptions<PrincipalContext> options) :
            base(options)
        {

        }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Childrens { get; set; }
    }
}
