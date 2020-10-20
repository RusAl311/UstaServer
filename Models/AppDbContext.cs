using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UstaApi.Models;
using UstaApi.Models.Auth;

namespace UstaApi.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Master> Masters { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<MasterSpeciality> MasterSpecialities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MasterSpeciality>()
                .HasKey(t => new { t.MasterId, t.SpecialityId });

            modelBuilder.Entity<MasterSpeciality>()
                .HasOne(pt => pt.Master)
                .WithMany(p => p.MasterSpecialities)
                .HasForeignKey(pt => pt.MasterId);

            modelBuilder.Entity<MasterSpeciality>()
                .HasOne(pt => pt.Speciality)
                .WithMany(t => t.MasterSpecialities)
                .HasForeignKey(pt => pt.SpecialityId);
        }
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {
        }

    }
}

