using Microsoft.EntityFrameworkCore;
using C_Activity3.Models;

namespace C_Activity3.Data;

public class AppDbContext : DbContext
{
    public DbSet<Astronaut> Astronauts { get; set; }   
    public DbSet<Mision> Misions { get; set; }  
    public DbSet<Engineer> Engineers { get; set; }  
    public DbSet<Spaceship> Spaceships { get; set; }
    public DbSet<ExplorationRegister> Registers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=5.189.174.154;Port=5432;Database=postgres;Username=postgres;Password=1033491102");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*Astronaut lenght requirements*/
        modelBuilder.Entity<Astronaut>()
            .Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<Astronaut>()
            .Property(a => a.Lastname)
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<Astronaut>()
            .Property(a => a.Position)
            .HasMaxLength(50)
            .IsRequired();
        
        /*Engineers lenght requirements*/
        modelBuilder.Entity<Engineer>()
            .Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<Engineer>()
            .Property(a => a.Lastname)
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<Engineer>()
            .Property(a => a.Speciality)
            .HasMaxLength(50)
            .IsRequired();
        
        /*Missions foreign key*/
        modelBuilder.Entity<Mision>()
            .HasOne(m => m.Astronaut)
            .WithMany(a => a.Misions)
            .HasForeignKey(m => m.AstronautId);
        
        modelBuilder.Entity<Mision>()
            .HasOne(m => m.Spaceship)
            .WithMany(s => s.Misions)
            .HasForeignKey(m => m.SpaceshipId);
        
        /*Exploration Register foreign key*/
        modelBuilder.Entity<ExplorationRegister>()
            .HasOne(e => e.Mision)
            .WithMany(r => r.Registers)
            .HasForeignKey(e => e.MisionId);
    }
}