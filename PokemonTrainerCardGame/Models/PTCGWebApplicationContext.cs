using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PokemonTrainerCardGame.Models
{
    public partial class PTCGWebApplicationContext : DbContext
    {
        public PTCGWebApplicationContext()
        {
        }

        public PTCGWebApplicationContext(DbContextOptions<PTCGWebApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardAttribute> CardAttributes { get; set; }
        public virtual DbSet<CardInfomation> CardInfomations { get; set; }
        public virtual DbSet<CardInformationPro> CardInfomationPros { get; set; }
        public virtual DbSet<CardRank> CardRanks { get; set; }
        public virtual DbSet<CardSpecialRule> CardSpecialRules { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<CardTypeDetail> CardTypeDetails { get; set; }
        public virtual DbSet<CardVersion> CardVersions { get; set; }
        public virtual DbSet<CardVersionDetail> CardVersionDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;Database=PTCGWebApplication; User=sa;Password=cgp3716;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<CardAttribute>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CardInfomation>(entity =>
            {
                entity.ToTable("CardInfomation");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("ImgURL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CardInformationPro>(entity =>
            {
                entity.ToTable("CardInfomationPro");

                entity.Property(e => e.Attribute).HasMaxLength(50);

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.ImgUrl).HasColumnName("ImgURL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rank).HasMaxLength(50);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.SpecialRule).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeDetail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VersionEnvironment)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CardRank>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CardRank");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CardSpecialRule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CardSpecialRule");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CardType");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CardTypeDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CardTypeDetail");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CardVersion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CardVersion");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CardVersionDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CardVersionDetail");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
