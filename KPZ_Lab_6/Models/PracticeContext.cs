using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KPZ_Lab_6.Models
{
    public partial class PracticeContext : DbContext
    {
        public PracticeContext()
        {
        }

        public PracticeContext(DbContextOptions<PracticeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<MigrationDemo> MirarionDemos{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=5CD110DFXQ\\SQLEXPRESS;Database=Practice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK_DEP_Department");

                entity.ToTable("Department");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("dept_name");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("location");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PK__Employee__129850FA0C0A47DE");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpNo)
                    .ValueGeneratedNever()
                    .HasColumnName("emp_no");

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("dept_no")
                    .IsFixedLength(true);

                entity.Property(e => e.EmpFname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("emp_fname");

                entity.Property(e => e.EmpLname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("emp_lname");

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__dept_n__267ABA7A");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectNo)
                    .HasName("PK__Project__BC79D7FB7EA6F4C7");

                entity.ToTable("Project");

                entity.Property(e => e.ProjectNo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("project_no")
                    .IsFixedLength(true);

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("project_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
