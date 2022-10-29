using BaseFileUpload.Entities;
using Microsoft.EntityFrameworkCore;  

namespace BaseFileUpload.DataAccess.Context;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
    {

    }

    public DbSet<ImageEntity> Images { get; set; }
}

