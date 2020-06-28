using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class ServiceDBContext : DbContext
    {
        public ServiceDBContext()
        {
        }

        public ServiceDBContext(DbContextOptions<ServiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrentDate> CurrentDate { get; set; }
        public virtual DbSet<DailyReport> DailyReport { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategory { get; set; }
        public virtual DbSet<Temperature> Temperature { get; set; }
        public virtual DbSet<Week> Week { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrentDate>(entity =>
            {
                entity.HasKey(e => e.CurrentDateId)
                    .IsClustered(false);

                entity.Property(e => e.CurrentDateId).ValueGeneratedNever();

                entity.Property(e => e.DateName).HasColumnType("date");
            });

            modelBuilder.Entity<DailyReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .IsClustered(false);

                entity.Property(e => e.ReportId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Service1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Service2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Service3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Service4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CurrentDate)
                    .WithMany(p => p.DailyReport)
                    .HasForeignKey(d => d.CurrentDateId)
                    .HasConstraintName("FK_CurrentDate_DailyReport");

                entity.HasOne(d => d.Week)
                    .WithMany(p => p.DailyReport)
                    .HasForeignKey(d => d.WeekId)
                    .HasConstraintName("FK_Week_DailyReport");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .IsClustered(false);

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .IsClustered(false);

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .IsClustered(false);

                entity.Property(e => e.MemberId).ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.DigitalAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Othernames)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SeatNumber)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.CurrentDate)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CurrentDateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrentDate_Members");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Members");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender_Members");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceCategory_Members");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.HasKey(e => e.ServiceCategoryId)
                    .IsClustered(false);

                entity.Property(e => e.ServiceCategoryId).ValueGeneratedNever();

                entity.Property(e => e.MemberCounts).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.ServiceCategoryName)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Temperature>(entity =>
            {
                entity.HasKey(e => e.TemperatureId)
                    .IsClustered(false);

                entity.Property(e => e.TemperatureId).ValueGeneratedNever();

                entity.Property(e => e.TempuratureNumber).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Temperature)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Members_Temperature");

                entity.HasOne(d => d.Week)
                    .WithMany(p => p.Temperature)
                    .HasForeignKey(d => d.WeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Week_Temperature");
            });

            modelBuilder.Entity<Week>(entity =>
            {
                entity.HasKey(e => e.WeekId)
                    .IsClustered(false);

                entity.Property(e => e.WeekId).ValueGeneratedNever();

                entity.Property(e => e.WeekName)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
