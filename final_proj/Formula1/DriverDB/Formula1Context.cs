using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DriverDB
{
    public partial class Formula1Context : DbContext
    {
        public Formula1Context()
        {
        }

        public Formula1Context(DbContextOptions<Formula1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDriver> TblDriver { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Formula1;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDriver>(entity =>
            {
                entity.ToTable("tbl_driver");

                entity.Property(e => e.CircuitName).HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Points).HasMaxLength(1000);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.TeamName).HasMaxLength(50);
            });
        }
    }
}
