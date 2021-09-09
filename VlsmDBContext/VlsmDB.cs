using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VlsmDBContext
{
    public partial class VlsmDB : DbContext
    {
        public VlsmDB()
        {
        }

        public VlsmDB(DbContextOptions<VlsmDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Vlsmresult> Vlsmresults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=VlsmDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
