using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class DatabaseEinsContext : DbContext
    {
        public DatabaseEinsContext()
        {
        }

        public DatabaseEinsContext(DbContextOptions<DatabaseEinsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agressor> Agressors { get; set; }
        public virtual DbSet<Bedrohung> Bedrohungs { get; set; }
        public virtual DbSet<Held> Helds { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DatabaseEins;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agressor>(entity =>
            {
                entity.ToTable("Agressor");

                entity.Property(e => e.AgressorId)
                    .ValueGeneratedNever()
                    .HasColumnName("agressor_id");

                entity.Property(e => e.AgressorEigenschaft)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("agressor_eigenschaft")
                    .IsFixedLength(true);

                entity.Property(e => e.AgressorName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("agressor_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Bedrohung>(entity =>
            {
                entity.ToTable("Bedrohung");

                entity.Property(e => e.BedrohungId)
                    .ValueGeneratedNever()
                    .HasColumnName("bedrohung_id");

                entity.Property(e => e.AgressorId).HasColumnName("agressor_id");

                entity.Property(e => e.Bedrohungsbezeichnung)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("bedrohungsbezeichnung")
                    .IsFixedLength(true);

                entity.Property(e => e.HeldId).HasColumnName("held_id");

                entity.HasOne(d => d.Agressor)
                    .WithMany(p => p.Bedrohungs)
                    .HasForeignKey(d => d.AgressorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bedrohung_agressor");

                entity.HasOne(d => d.Held)
                    .WithMany(p => p.Bedrohungs)
                    .HasForeignKey(d => d.HeldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bedrohung_held");
            });

            modelBuilder.Entity<Held>(entity =>
            {
                entity.ToTable("Held");

                entity.Property(e => e.HeldId)
                    .ValueGeneratedNever()
                    .HasColumnName("held_id");

                entity.Property(e => e.HeldEigenschaft)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("held_eigenschaft")
                    .IsFixedLength(true);

                entity.Property(e => e.HeldName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("held_name")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
