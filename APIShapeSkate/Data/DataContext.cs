using Microsoft.EntityFrameworkCore;

namespace APIShapeSkate.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> opt) 
            : base(opt)
        {

        }

        public DbSet<Shape> Shapes { get; set; }


    }
}
