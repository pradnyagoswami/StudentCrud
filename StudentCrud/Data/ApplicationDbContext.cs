using Microsoft.EntityFrameworkCore;
using StudentCrud.Models;

namespace StudentCrud.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>  op) :base(op){ 


        
        }

        public DbSet<Student>? Students { get; set; }
    }
}
