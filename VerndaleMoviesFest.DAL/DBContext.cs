using Microsoft.EntityFrameworkCore;
using VerndaleMoviesFest.DAL.Entities;

namespace VerndaleMoviesFest.DAL
{
    public partial class DBContext : DbContext
    {
        public DBContext(){}

        public DBContext(DbContextOptions<DBContext> options): base(options){}

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PRIMARY");

                entity.ToTable("genre");

                entity.Property(e => e.IdGenre).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie)
                    .HasName("PRIMARY");

                entity.ToTable("movie");

                entity.HasIndex(e => e.IdGenre, "fk_Pelicula_Genero_idx");

                entity.Property(e => e.IdMovie).HasColumnType("int(11)");

                entity.Property(e => e.Duration).HasColumnType("int(11)");

                entity.Property(e => e.IdGenre).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Synopsis)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pelicula_Genero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
