using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace QcaugmenteBackend.Models
{
    public class DB : DbContext
    {
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<PisteCyclable> PisteCyclable { get; set; }
        public DbSet<Endroit> Endroits { get; set; }
        public DbSet<Parc> Parcs { get; set; }
        public DbSet<Zap> Zaps { get; set; }

        public DB()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evenement>().HasKey(e => e.ID);
            modelBuilder.Entity<PisteCyclable>().HasKey(p => p.PISTECYCLABLE_IDG);
            modelBuilder.Entity<Endroit>().HasKey(e => e.id);
            modelBuilder.Entity<Parc>().HasKey(p => p.id);
            modelBuilder.Entity<Zap>().HasKey(z => z.id);
        }
    }
}