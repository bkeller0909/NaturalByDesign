using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBDv2.Models;

namespace NBDv2.Data
{
    public class NBDContext : DbContext
    {
        public NBDContext (DbContextOptions<NBDContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Bid> Bids { get; set; } // database set for the bids

        public DbSet<InventoryBid> InvBids { get; set; } // database set for the inventory bid

        public DbSet<LabourSummary> LabourSummaries { get; set; }

        public DbSet<Labour> Labours { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<ProjectMaterials> ProjectMaterials { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MC");

            modelBuilder.Entity<City>()
                .HasMany<Client>(c => c.Clients)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasMany<Project>(c => c.Projects)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeType>()
                .HasMany<Employee>(e => e.Employees)
                .WithOne(p => p.EmployeeType)
                .HasForeignKey(p => p.EmployeeTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany<Project>(e => e.Projects)
                .WithOne(p => p.Designer)
                .HasForeignKey(p => p.DesignerID)
                .OnDelete(DeleteBehavior.Restrict);

            // model builder for inventory bid
            modelBuilder.Entity<InventoryBid>()
                .HasKey(b => new { b.BidID, b.ItemID });

            modelBuilder.Entity<ProjectEmployee>()
                .HasMany<Labour>(c => c.Labours)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Models.Task>()
                .HasMany<Labour>(l => l.Labours)
                .WithOne(t => t.Task)
                .HasForeignKey(p => p.TaskID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectMaterials>()
                .HasKey(t => new { t.ProjectID, t.InventoryID });

            modelBuilder.Entity<LabourSummary>()
                .HasKey(t => new { t.ProjectID, t.EmployeeTypeID });
        }

        
        
        

        public DbSet<NBDv2.Models.BidReport> BidReport { get; set; }
    }
}
