using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieRater.Database
{
    public partial class MovieRaterDBContext : DbContext
    {
        public MovieRaterDBContext()
        {
        }

        public MovieRaterDBContext(DbContextOptions<MovieRaterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actors> Actors { get; set; }
        public virtual DbSet<ArticleActorRelation> ArticleActorRelation { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=.;Database=MistralDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actors>(entity =>
            {
                entity.HasKey(e => e.ActorId)
                    .HasName("PK__Actors__57B3EA2BBEE5A33E");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ArticleActorRelation>(entity =>
            {
                entity.HasKey(e => e.RelationId)
                    .HasName("PK__ArticleA__E2DA1695CEEEB661");

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ArticleActorRelation)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticleAc__Actor__37A5467C");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleActorRelation)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticleAc__Artic__38996AB5");
            });

            modelBuilder.Entity<Articles>(entity =>
            {
                entity.HasKey(e => e.ArticleId)
                    .HasName("PK__Articles__9C6270C8BA359864");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId)
                    .HasName("PK__Korisnic__80B06D61BA5B40FA");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.DatumRodjenja).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime).HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(15);

                entity.Property(e => e.LozinkaHash).HasMaxLength(150);

                entity.Property(e => e.LozinkaSalt).HasMaxLength(150);

                entity.Property(e => e.Prezime).HasMaxLength(20);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rating__ArticleI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
