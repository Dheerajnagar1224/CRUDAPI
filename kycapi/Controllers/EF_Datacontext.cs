using Microsoft.EntityFrameworkCore;

public class EF_Datacontext : DbContext
{

    public EF_Datacontext(DbContextOptions<EF_Datacontext> options) : base(options) { }
    public DbSet<Entity> Entities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityConfiguration());
    }

 
}
