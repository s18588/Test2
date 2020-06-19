using Microsoft.EntityFrameworkCore;

namespace Test2.Models
{
    public class PetStoreDbContext : DbContext
    {
        public DbSet<Pet> Pet { get; set; }
        public DbSet<BreedType> BreedType { get; set; }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<Volunteer_Pet> Volunteer_Pet { get; set; }
        

        public PetStoreDbContext()
        {
        }

        public PetStoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Volunteer_Pet>()
                .HasKey(e => new {e.IdVolunteer, e.IdPet});
        }
        
    }
}