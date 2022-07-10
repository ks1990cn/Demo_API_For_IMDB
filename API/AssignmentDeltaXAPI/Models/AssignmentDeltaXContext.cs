using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AssignmentDeltaXAPI.Models
{
    public partial class AssignmentDeltaXContext : DbContext
    {
        public AssignmentDeltaXContext()
        {
        }

        public AssignmentDeltaXContext(DbContextOptions<AssignmentDeltaXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Moviesactor> Moviesactors { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:AssignmentDeltaXString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("Actor");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.ActorName).IsUnicode(false);

                entity.Property(e => e.Bio).IsUnicode(false);

                entity.Property(e => e.Company).IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.Dor)
                    .HasColumnType("date")
                    .HasColumnName("DOR");

                entity.Property(e => e.MovieName).IsUnicode(false);

                entity.Property(e => e.Plot).IsUnicode(false);

                entity.Property(e => e.Poster).IsUnicode(false);

                entity.Property(e => e.Producerid).HasColumnName("PRODUCERID");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Producerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Movies__PRODUCER__30F848ED");
            });

            modelBuilder.Entity<Moviesactor>(entity =>
            {
                entity.HasKey(e => new { e.Moviesid, e.Actorsid })
                    .HasName("PK__MOVIESAC__E584FDFE1C3B0877");

                entity.ToTable("MOVIESACTORS");

                entity.Property(e => e.Moviesid).HasColumnName("MOVIESID");

                entity.Property(e => e.Actorsid).HasColumnName("ACTORSID");

                entity.HasOne(d => d.Actors)
                    .WithMany(p => p.Moviesactors)
                    .HasForeignKey(d => d.Actorsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIESACT__ACTOR__2F10007B");

                entity.HasOne(d => d.Movies)
                    .WithMany(p => p.Moviesactors)
                    .HasForeignKey(d => d.Moviesid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIESACT__MOVIE__2E1BDC42");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");

                entity.Property(e => e.ProducerId).HasColumnName("ProducerID");

                entity.Property(e => e.Bio).IsUnicode(false);

                entity.Property(e => e.Company).IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
