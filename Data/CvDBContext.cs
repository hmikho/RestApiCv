using Backend_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Api.Data
{
    public class CvDBContext : DbContext
    {
        public CvDBContext(DbContextOptions<CvDBContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Personer { get; set; }

        public DbSet<Utbildning> Utbildningar { get; set; }
        
        public DbSet<Arbetserfarenhet> Arbetserfarenheter { get; set; }

    }
}
