using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess
{
    public partial class AmisProcessDbContext : DbContext
    {
        public AmisProcessDbContext()
        {

        }

        public AmisProcessDbContext(DbContextOptions<AmisProcessDbContext> options)
            : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

            public virtual DbSet<Employee> Employee { get; set; }
            public virtual DbSet<Field> Field { get; set; }
            public virtual DbSet<FieldValue> Fieldvalue { get; set; }
            public virtual DbSet<Phase> Phase { get; set; }
            public virtual DbSet<Process> Process { get; set; }
            public virtual DbSet<ProcessCategory> ProcessCategory { get; set; }
            public virtual DbSet<ProcessRunning> ProcessRunning { get; set; }
            public virtual DbSet<Role> Role { get; set; }
            public virtual DbSet<User> User { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseMySQL("server=localhost;port=3307;user=root;password=12345678;database=misa.amisprocess");
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_Employee_User_idx");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FrirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Employee_User");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.ToTable("field");

                entity.HasIndex(e => e.PhaseId)
                    .HasName("FK_Field_Phase_idx");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Required).HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.Field)
                    .HasForeignKey(d => d.PhaseId)
                    .HasConstraintName("FK_Field_Phase");
            });

            modelBuilder.Entity<FieldValue>(entity =>
            {
                entity.ToTable("fieldvalue");

                entity.HasIndex(e => e.FieldId)
                    .HasName("FK_FieldId_idx");

                entity.HasIndex(e => e.ProcessRunningId)
                    .HasName("FK_FieldValue_ProcessRunning_idx");

                entity.Property(e => e.Value).HasColumnType("mediumtext");

                entity.Property(e => e.ValueForCheckBox)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.FieldValue)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_FieldValue_Field");

                entity.HasOne(d => d.ProcessRunning)
                    .WithMany(p => p.Fieldvalue)
                    .HasForeignKey(d => d.ProcessRunningId)
                    .HasConstraintName("FK_FieldValue_ProcessRunning");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("option");

                entity.HasIndex(e => e.FieldId)
                    .HasName("FK_Field_Option_FieldId_idx");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_Field_Option_FieldId");
            });

            modelBuilder.Entity<Phase>(entity =>
            {
                entity.ToTable("phase");

                entity.HasIndex(e => e.ProcessId)
                    .HasName("FK_Phase_Process_idx");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeImplement).HasColumnType("mediumtext");

                entity.Property(e => e.EmployeeImplementType)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsFirstPhase).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsLastPhase).HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeImplementType)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.Phase)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_Phase_Process");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("process");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_Process_ProcessCategory_idx");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Process_ProcessCategory");
            });

            modelBuilder.Entity<ProcessCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("processcategory");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProcessRunning>(entity =>
            {
                entity.ToTable("processrunning");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_ProcessRunning_Employee_idx");

                entity.HasIndex(e => e.PhaseId)
                    .HasName("FK_ProcessRunning_Phase_idx");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProcessRunning)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRunning_Employee");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.ProcessRunning)
                    .HasForeignKey(d => d.PhaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcessRunning_Phase");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FR");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
    }

