using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlaystationGamer2.Models
{
    public partial class PlaystationGamerContext : DbContext
    {
        public PlaystationGamerContext()
        {
        }

        public PlaystationGamerContext(DbContextOptions<PlaystationGamerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Console> Console { get; set; }
        public virtual DbSet<Controllers> Controllers { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PlaystationGamer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("blog");

                entity.Property(e => e.BlogId).HasColumnName("blogID");

                entity.Property(e => e.BlogTitle)
                    .IsRequired()
                    .HasColumnName("blogTitle")
                    .HasMaxLength(500);

                entity.Property(e => e.BlogDate)
                    .IsRequired()
                    .HasColumnName("blogDate")
                    .HasMaxLength(500);

                entity.Property(e => e.BlogPost)
                    .IsRequired()
                    .HasColumnName("blogPost")
                    .HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Blog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__blog__userID__38996AB5");
            });

            modelBuilder.Entity<Console>(entity =>
            {
                entity.ToTable("console");

                entity.Property(e => e.ConsoleId).HasColumnName("consoleID");

                entity.Property(e => e.ConsoleName)
                    .IsRequired()
                    .HasColumnName("consoleName")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.Property(e => e.UnitsSold)
                    .IsRequired()
                    .HasColumnName("unitsSold")
                    .HasMaxLength(50);

                entity.Property(e => e.YearReleased).HasColumnName("yearReleased");
            });

            modelBuilder.Entity<Controllers>(entity =>
            {
                entity.HasKey(e => e.ControllerId);

                entity.ToTable("controllers");

                entity.Property(e => e.ControllerId).HasColumnName("controllerID");

                entity.Property(e => e.ConsoleId).HasColumnName("consoleID");

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasColumnName("controllerName")
                    .HasMaxLength(100);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.Property(e => e.YearReleased).HasColumnName("yearReleased");

                entity.HasOne(d => d.Console)
                    .WithMany(p => p.Controllers)
                    .HasForeignKey(d => d.ConsoleId)
                    .HasConstraintName("FK__controlle__conso__3F466844");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.GameId).HasColumnName("gameID");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasMaxLength(30);

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasColumnName("titleName")
                    .HasMaxLength(100);

                entity.Property(e => e.YearReleased).HasColumnName("yearReleased");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoPath)
                    .HasColumnName("photoPath")
                    .HasMaxLength(200);

                entity.Property(e => e.UserAccountId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(20);
            });
        }
    }
}
