using Microsoft.EntityFrameworkCore;
using kolos2.Entities.Models;
using System;

namespace kolos2.Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Musican> Musican { get; set; }
        public DbSet<MusicanTrack> MusicanTrack { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Track> Track { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musican>(e =>
            {
                e.ToTable("Musican");
                e.HasKey(e => e.IdMusican);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20);

                e.HasData(
                    new Musican
                    {
                        IdMusican = 1,
                        FirstName = "Michal",
                        LastName = "Kowalski",
                        NickName = "Kowalski"
                    }
                );

            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.ToTable("MusicLabel");
                e.HasKey(e => e.IdMusicLabel);

                e.Property(e => e.Name).HasMaxLength(50).IsRequired();


                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "FajnaLista",
                    }
                );
            });

            modelBuilder.Entity<MusicanTrack>(e =>
            {
                e.ToTable("MusicanTrack");
                e.HasKey(e => new { e.IdMusican, e.IdTrack });


                e.HasOne(e => e.Track).WithMany(e => e.MusicanTrack).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.Musican).WithMany(e => e.MusicanTrack).HasForeignKey(e => e.IdMusican).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new MusicanTrack
                    {
                        IdMusican = 1,
                        IdTrack = 1,
                    }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);



                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdMusicAlbum);

                e.HasOne(e => e.Album).WithMany(e => e.Track).HasForeignKey(e => e.IdMusicAlbum).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Magdalenek",
                        Duration = 1.50F,
                        IdMusicAlbum = 1,
                    }
                );

            });

            modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);

                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "ASSSSSS",
                        PublishDate = DateTime.Now,
                        IdMusicLabel = 1,
                    }
                );
            });
        }
    }
}
