using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaapHrmApi.Model
{
    public partial class db_taapHrmContext : DbContext
    {
        public db_taapHrmContext()
        {
        }

        public db_taapHrmContext(DbContextOptions<db_taapHrmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VtChoice> VtChoice { get; set; }
        public virtual DbSet<VtQuestion> VtQuestion { get; set; }
        public virtual DbSet<VtScore> VtScore { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VtChoice>(entity =>
            {
                entity.ToTable("VT_Choice");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Choice)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ImgName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImgSource).IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VtQuestion>(entity =>
            {
                entity.ToTable("VT_Question");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Answer)
                    .IsUnicode(false);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ImgName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImgSource).IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VtScore>(entity =>
            {
                entity.ToTable("VT_Score");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CareerType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
