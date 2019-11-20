using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfessorSoftware>()
                .HasKey(ps => new { ps.ProfessorID, ps.SoftwareID });

            modelBuilder.Entity<ProfessorSoftware>()
                .HasOne(ps => ps.Professor)
                .WithMany(p => p.NeededSoftware)
                .HasForeignKey(ps => ps.ProfessorID);

            modelBuilder.Entity<ProfessorSoftware>()
               .HasOne(ps => ps.Software)
               .WithMany(s => s.NeededBy);

             modelBuilder.Entity<SystemSoftware>()
                .HasKey(ps => new { ps.CSSystemID, ps.SoftwareID });

            modelBuilder.Entity<SystemSoftware>()
                .HasOne(ps => ps.CSSystem)
                .WithMany(p => p.NeededSoftware)
                .HasForeignKey(ps => ps.CSSystemID);

            modelBuilder.Entity<SystemSoftware>()
               .HasOne(ps => ps.Software)
               .WithMany(s => s.NeededOn)
               .HasForeignKey(ps => ps.SoftwareID);

        }

        public DbSet<FinalProject.Models.Professor> Professors { get; set; }
        public DbSet<FinalProject.Models.InventoryItem> InventoryItems { get; set; }
        public DbSet<FinalProject.Models.ProfessorSoftware> ProfessorSoftware { get; set; }
        public DbSet<FinalProject.Models.Software> Software { get; set; }
        public DbSet<FinalProject.Models.CSSystem> CSSystems { get; set; }
        public DbSet<FinalProject.Models.SystemSoftware > SystemSoftware { get; set; }
    }
}
