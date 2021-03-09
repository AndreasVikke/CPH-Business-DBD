using Microsoft.EntityFrameworkCore;
using VetExercise.DataModels;

namespace VetExercise.Persistent
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {         
        }
        
        public DbSet<Address> addresses { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Caretaker> caretakers { get; set; }
        public DbSet<Vet> vets { get; set; }

        public DbSet<Pet> pets { get; set; }
        public DbSet<Dog> dogs { get; set; }
        public DbSet<Cat> cats { get; set; }
    }
}