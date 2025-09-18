using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorAward>(entity =>
            {
                entity.ToTable("AuthorAwardBridge");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(a => a.DateOfBirth).HasColumnName("Birthday");
            });

            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AuthorAwards)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorAward>()
               .HasOne(aa => aa.Award)
               .WithMany(a => a.AuthorAwards)
               .HasForeignKey(aa => aa.AwardId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey("PublisherId")
                .OnDelete(DeleteBehavior.Restrict);

            // --- Autori ---
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "Ana Radmanović", Biography = "Pisac iz Srbije", DateOfBirth = new DateTime(1998, 5, 7, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 2, FullName = "Marko Jovanović", Biography = "Romantični pisac", DateOfBirth = new DateTime(1985, 8, 12, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 3, FullName = "Jelena Petrović", Biography = "Pisac naučne fantastike", DateOfBirth = new DateTime(1990, 3, 20, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 4, FullName = "Nikola Stojanović", Biography = "Poezija i proza", DateOfBirth = new DateTime(1975, 11, 2, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 5, FullName = "Marija Ilić", Biography = "Mladi pisac", DateOfBirth = new DateTime(2000, 1, 15, 0, 0, 0, DateTimeKind.Utc) }
            );

            // --- Izdavači ---
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Laguna", Address = "Beograd", Website = "https://laguna.rs" },
                new Publisher { Id = 2, Name = "Vulkan", Address = "Beograd", Website = "https://vulkan.rs" },
                new Publisher { Id = 3, Name = "Dereta", Address = "Beograd", Website = "https://dereta.rs" }
            );

            // --- Knjige ---
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Knjiga 1", PageCount = 200, PublishedDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "111111", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Knjiga 2", PageCount = 150, PublishedDate = new DateTime(2019, 5, 10, 0, 0, 0, DateTimeKind.Utc), ISBN = "222222", AuthorId = 1, PublisherId = 2 },
                new Book { Id = 3, Title = "Knjiga 3", PageCount = 300, PublishedDate = new DateTime(2018, 7, 20, 0, 0, 0, DateTimeKind.Utc), ISBN = "333333", AuthorId = 2, PublisherId = 1 },
                new Book { Id = 4, Title = "Knjiga 4", PageCount = 120, PublishedDate = new DateTime(2021, 3, 15, 0, 0, 0, DateTimeKind.Utc), ISBN = "444444", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 5, Title = "Knjiga 5", PageCount = 250, PublishedDate = new DateTime(2017, 11, 30, 0, 0, 0, DateTimeKind.Utc), ISBN = "555555", AuthorId = 3, PublisherId = 3 },
                new Book { Id = 6, Title = "Knjiga 6", PageCount = 180, PublishedDate = new DateTime(2022, 6, 5, 0, 0, 0, DateTimeKind.Utc), ISBN = "666666", AuthorId = 3, PublisherId = 1 },
                new Book { Id = 7, Title = "Knjiga 7", PageCount = 220, PublishedDate = new DateTime(2020, 12, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "777777", AuthorId = 4, PublisherId = 2 },
                new Book { Id = 8, Title = "Knjiga 8", PageCount = 260, PublishedDate = new DateTime(2019, 8, 8, 0, 0, 0, DateTimeKind.Utc), ISBN = "888888", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 9, Title = "Knjiga 9", PageCount = 140, PublishedDate = new DateTime(2021, 2, 20, 0, 0, 0, DateTimeKind.Utc), ISBN = "999999", AuthorId = 5, PublisherId = 1 },
                new Book { Id = 10, Title = "Knjiga 10", PageCount = 300, PublishedDate = new DateTime(2022, 9, 10, 0, 0, 0, DateTimeKind.Utc), ISBN = "101010", AuthorId = 5, PublisherId = 3 },
                new Book { Id = 11, Title = "Knjiga 11", PageCount = 210, PublishedDate = new DateTime(2018, 4, 5, 0, 0, 0, DateTimeKind.Utc), ISBN = "111212", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 12, Title = "Knjiga 12", PageCount = 190, PublishedDate = new DateTime(2021, 7, 12, 0, 0, 0, DateTimeKind.Utc), ISBN = "121212", AuthorId = 2, PublisherId = 2 }
            );

            // --- Nagrade ---
            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Nagrada 1", Description = "Prva nagrada", YearEstablished = 2000 },
                new Award { Id = 2, Name = "Nagrada 2", Description = "Druga nagrada", YearEstablished = 2005 },
                new Award { Id = 3, Name = "Nagrada 3", Description = "Treća nagrada", YearEstablished = 2010 },
                new Award { Id = 4, Name = "Nagrada 4", Description = "Četvrta nagrada", YearEstablished = 2015 }
            );

            // --- AuthorAward veze ---
            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { Id = 1, AuthorId = 1, AwardId = 1, YearAwarded = 2020 },
                new AuthorAward { Id = 2, AuthorId = 1, AwardId = 2, YearAwarded = 2021 },
                new AuthorAward { Id = 3, AuthorId = 2, AwardId = 1, YearAwarded = 2019 },
                new AuthorAward { Id = 4, AuthorId = 2, AwardId = 3, YearAwarded = 2020 },
                new AuthorAward { Id = 5, AuthorId = 3, AwardId = 2, YearAwarded = 2021 },
                new AuthorAward { Id = 6, AuthorId = 3, AwardId = 4, YearAwarded = 2022 },
                new AuthorAward { Id = 7, AuthorId = 4, AwardId = 1, YearAwarded = 2018 },
                new AuthorAward { Id = 8, AuthorId = 4, AwardId = 3, YearAwarded = 2019 },
                new AuthorAward { Id = 9, AuthorId = 5, AwardId = 2, YearAwarded = 2020 },
                new AuthorAward { Id = 10, AuthorId = 5, AwardId = 4, YearAwarded = 2021 },
                new AuthorAward { Id = 11, AuthorId = 1, AwardId = 3, YearAwarded = 2022 },
                new AuthorAward { Id = 12, AuthorId = 2, AwardId = 4, YearAwarded = 2022 },
                new AuthorAward { Id = 13, AuthorId = 3, AwardId = 1, YearAwarded = 2020 },
                new AuthorAward { Id = 14, AuthorId = 4, AwardId = 2, YearAwarded = 2021 },
                new AuthorAward { Id = 15, AuthorId = 5, AwardId = 3, YearAwarded = 2022 }
            );
        }
    }
}
