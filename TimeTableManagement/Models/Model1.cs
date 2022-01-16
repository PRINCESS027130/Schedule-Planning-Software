using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TimeTableManagement.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<ADMIN_TBL> ADMIN_TBL { get; set; }
        public virtual DbSet<CLASS_TBL> CLASS_TBL { get; set; }
        public virtual DbSet<COURSE_ASSIGN_TBL> COURSE_ASSIGN_TBL { get; set; }
        public virtual DbSet<COURSE_TBL> COURSE_TBL { get; set; }
        public virtual DbSet<DEGREE_TBL> DEGREE_TBL { get; set; }
        public virtual DbSet<DEPARTMENT_TBL> DEPARTMENT_TBL { get; set; }
        public virtual DbSet<ROOM_TBL> ROOM_TBL { get; set; }
        public virtual DbSet<SLOT_TBL> SLOT_TBL { get; set; }
        public virtual DbSet<STUDENT_TBL> STUDENT_TBL { get; set; }
        public virtual DbSet<TEACHER_TBL> TEACHER_TBL { get; set; }
        public virtual DbSet<TIMETABLE_TBL> TIMETABLE_TBL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLASS_TBL>()
                .HasMany(e => e.STUDENT_TBL)
                .WithRequired(e => e.CLASS_TBL)
                .HasForeignKey(e => e.CLASS_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLASS_TBL>()
                .HasMany(e => e.TIMETABLE_TBL)
                .WithRequired(e => e.CLASS_TBL)
                .HasForeignKey(e => e.CLASS_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE_ASSIGN_TBL>()
                .HasMany(e => e.TIMETABLE_TBL)
                .WithRequired(e => e.COURSE_ASSIGN_TBL)
                .HasForeignKey(e => e.COURSE_ASSIGN_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE_TBL>()
                .HasMany(e => e.COURSE_ASSIGN_TBL)
                .WithRequired(e => e.COURSE_TBL)
                .HasForeignKey(e => e.COURSE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_TBL>()
                .HasMany(e => e.CLASS_TBL)
                .WithRequired(e => e.DEGREE_TBL)
                .HasForeignKey(e => e.DEGREE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_TBL>()
                .HasMany(e => e.COURSE_ASSIGN_TBL)
                .WithRequired(e => e.DEGREE_TBL)
                .HasForeignKey(e => e.DEGREE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEGREE_TBL>()
                .HasMany(e => e.COURSE_TBL)
                .WithRequired(e => e.DEGREE_TBL)
                .HasForeignKey(e => e.DEGREE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT_TBL>()
                .HasMany(e => e.DEGREE_TBL)
                .WithRequired(e => e.DEPARTMENT_TBL)
                .HasForeignKey(e => e.DEPARTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT_TBL>()
                .HasMany(e => e.ROOM_TBL)
                .WithRequired(e => e.DEPARTMENT_TBL)
                .HasForeignKey(e => e.DEPARTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT_TBL>()
                .HasMany(e => e.TEACHER_TBL)
                .WithRequired(e => e.DEPARTMENT_TBL)
                .HasForeignKey(e => e.DEPARTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROOM_TBL>()
                .HasMany(e => e.TIMETABLE_TBL)
                .WithRequired(e => e.ROOM_TBL)
                .HasForeignKey(e => e.ROOM_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SLOT_TBL>()
                .HasMany(e => e.TIMETABLE_TBL)
                .WithRequired(e => e.SLOT_TBL)
                .HasForeignKey(e => e.SLOT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHER_TBL>()
                .HasMany(e => e.TIMETABLE_TBL)
                .WithRequired(e => e.TEACHER_TBL)
                .HasForeignKey(e => e.TEACHER_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
