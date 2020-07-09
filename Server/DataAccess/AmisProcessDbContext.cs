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
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<FieldOption> FieldOption { get; set; }
        public virtual DbSet<FieldValue> FieldValue { get; set; }
        public virtual DbSet<Phase> Phase { get; set; }
        public virtual DbSet<PhaseEmployee> PhaseEmployee { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<ProcessRunning> ProcessRunning { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=192.168.15.18;port=3306;user=dev;password=12345678@Abc;database=MISA.AmisProcess", x => x.ServerVersion("10.3.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("Fk_Employee_User_UserId_idx");

                entity.Property(e => e.EmployeeId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_employee_user_UserId");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.HasIndex(e => e.PhaseId)
                    .HasName("fk_phase_field_idx");

                entity.Property(e => e.FieldId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhaseId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Required)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.Field)
                    .HasForeignKey(d => d.PhaseId)
                    .HasConstraintName("FK_field_phase_PhaseId");
            });

            modelBuilder.Entity<FieldOption>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.FieldId)
                    .HasName("FK_option_field_fieldId_idx");

                entity.Property(e => e.OptionId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FieldId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.FieldOption)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_option_field_FieldId");
            });

            modelBuilder.Entity<FieldValue>(entity =>
            {
                entity.HasIndex(e => e.FieldId)
                    .HasName("fk_field_fieldvalue_idx");

                entity.HasIndex(e => e.ProcessRunningId)
                    .HasName("fk_processrunning_fieldvalue_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FieldId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProcessRunningId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ValueForCheckBox)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.FieldValue)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_fieldvalue_field_FieldId");

                entity.HasOne(d => d.ProcessRunning)
                    .WithMany(p => p.FieldValue)
                    .HasForeignKey(d => d.ProcessRunningId)
                    .HasConstraintName("FK_fieldvalue_processrunning_ProcessRunningId");
            });

            modelBuilder.Entity<Phase>(entity =>
            {
                entity.HasIndex(e => e.ProcessId)
                    .HasName("FK_phase_process_processId_idx");

                entity.Property(e => e.PhaseId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EmployeeImplement)
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EmployeeImplementType)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Posittion)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'")
                    .HasComment("Vi tri cua phase trong process: 1 dau, 2 giua, 3 cuoi");

                entity.Property(e => e.ProcessId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Serial).HasColumnType("int(11)");

                entity.Property(e => e.TimeImplement).HasColumnType("int(11)");

                entity.Property(e => e.TimeImplementType)
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.Phase)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_phase_process_ProcessId");
            });

            modelBuilder.Entity<PhaseEmployee>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_employee_phaseemployee_employeeId_idx");

                entity.HasIndex(e => e.PhaseId)
                    .HasName("FK_employee_phaseemployee_phaseId_idx");

                entity.Property(e => e.PhaseEmployeeId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhaseId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PhaseEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_phaseemployee_employee_EmployeeId");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.PhaseEmployee)
                    .HasForeignKey(d => d.PhaseId)
                    .HasConstraintName("FK_phaseemployee_phase_PhaseId");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("FK_process_category_CategoryId");

                entity.Property(e => e.ProcessId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CategoryId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_process_category_CategoryId");
            });

            modelBuilder.Entity<ProcessRunning>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("Fk_Employee_Processrunning_EmployeeId_idx");

                entity.HasIndex(e => e.PhaseId)
                    .HasName("Fk_Phase_Processrunning_PhaseId_idx");

                entity.Property(e => e.ProcessRunningId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.EmployeeHandleId)
                    .HasColumnType("varchar(36)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EmployeeId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhaseId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Status).HasColumnType("tinyint(4)");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProcessRunning)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_processrunning_employee_EmployeeId");

                entity.HasOne(d => d.Phase)
                    .WithMany(p => p.ProcessRunning)
                    .HasForeignKey(d => d.PhaseId)
                    .HasConstraintName("FK_processrunning_phase_PhaseId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleName)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("Fk_Role_User_RoleId_idx");

                entity.Property(e => e.UserId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Username)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_user_role_RoleId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
