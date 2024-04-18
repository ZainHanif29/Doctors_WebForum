using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doctors_WebForum.Models
{
    public partial class Doctors_WebForumContext : DbContext
    {
        public Doctors_WebForumContext()
        {
        }

        public Doctors_WebForumContext(DbContextOptions<Doctors_WebForumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminReg> AdminRegs { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<DoctorAppointment> DoctorAppointments { get; set; } = null!;
        public virtual DbSet<DoctorReg> DoctorRegs { get; set; } = null!;
        public virtual DbSet<Experience> Experiences { get; set; } = null!;
        public virtual DbSet<Privacy> Privacies { get; set; } = null!;
        public virtual DbSet<Qualification> Qualifications { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;
        public virtual DbSet<UserReg> UserRegs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KEBGC3D\\SQLEXPRESS;Initial Catalog=Doctors_WebForum;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminReg>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__Admin_Re__71AC6D411D18F2F6");

                entity.ToTable("Admin_Reg");

                entity.Property(e => e.AId).HasColumnName("A_ID");

                entity.Property(e => e.AEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("A_Email");

                entity.Property(e => e.AName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("A_Name");

                entity.Property(e => e.APassword)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("A_Password");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Contact__A9FDEC122BAA68C3");

                entity.ToTable("Contact");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.CEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("C_Email");

                entity.Property(e => e.CMsg)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_Msg");

                entity.Property(e => e.CName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("C_Name");

                entity.Property(e => e.CSubject)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("C_Subject");
            });

            modelBuilder.Entity<DoctorAppointment>(entity =>
            {
                entity.HasKey(e => e.ApId)
                    .HasName("PK__Doctor_A__9403383F0B53D323");

                entity.ToTable("Doctor_Appointment");

                entity.Property(e => e.ApId).HasColumnName("AP_ID");

                entity.Property(e => e.ApDate)
                    .HasColumnType("date")
                    .HasColumnName("AP_Date");

                entity.Property(e => e.ApEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AP_Email");

                entity.Property(e => e.ApMsg)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AP_Msg");

                entity.Property(e => e.ApName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AP_Name");

                entity.Property(e => e.ApPhone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AP_Phone");

                entity.Property(e => e.ApSpecialization).HasColumnName("AP_Specialization");

                entity.Property(e => e.DId).HasColumnName("D_ID");

                entity.HasOne(d => d.ApSpecializationNavigation)
                    .WithMany(p => p.DoctorAppointments)
                    .HasForeignKey(d => d.ApSpecialization)
                    .HasConstraintName("FK__Doctor_Ap__AP_Sp__5EBF139D");

                entity.HasOne(d => d.DIdNavigation)
                    .WithMany(p => p.DoctorAppointments)
                    .HasForeignKey(d => d.DId)
                    .HasConstraintName("FK__Doctor_App__D_ID__5FB337D6");
            });

            modelBuilder.Entity<DoctorReg>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__Doctor_R__76B8FF7DC93D30FC");

                entity.ToTable("Doctor_Reg");

                entity.Property(e => e.DId).HasColumnName("D_ID");

                entity.Property(e => e.DAchivement)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("D_Achivement");

                entity.Property(e => e.DAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("D_Address");

                entity.Property(e => e.DContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("D_Contact");

                entity.Property(e => e.DDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("D_Desc");

                entity.Property(e => e.DEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("D_Email");

                entity.Property(e => e.DExperience).HasColumnName("D_Experience");

                entity.Property(e => e.DName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("D_Name");

                entity.Property(e => e.DPassword)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("D_Password");

                entity.Property(e => e.DPrivacy).HasColumnName("D_Privacy");

                entity.Property(e => e.DQualification).HasColumnName("D_Qualification");

                entity.Property(e => e.DSpecialization).HasColumnName("D_Specialization");

                entity.HasOne(d => d.DExperienceNavigation)
                    .WithMany(p => p.DoctorRegs)
                    .HasForeignKey(d => d.DExperience)
                    .HasConstraintName("FK__Doctor_Re__D_Exp__5BE2A6F2");

                entity.HasOne(d => d.DPrivacyNavigation)
                    .WithMany(p => p.DoctorRegs)
                    .HasForeignKey(d => d.DPrivacy)
                    .HasConstraintName("FK__Doctor_Re__D_Pri__59063A47");

                entity.HasOne(d => d.DQualificationNavigation)
                    .WithMany(p => p.DoctorRegs)
                    .HasForeignKey(d => d.DQualification)
                    .HasConstraintName("FK__Doctor_Re__D_Qua__59FA5E80");

                entity.HasOne(d => d.DSpecializationNavigation)
                    .WithMany(p => p.DoctorRegs)
                    .HasForeignKey(d => d.DSpecialization)
                    .HasConstraintName("FK__Doctor_Re__D_Spe__5AEE82B9");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.EId)
                    .HasName("PK__Experien__D730AF544AF8FA4C");

                entity.ToTable("Experience");

                entity.Property(e => e.EId).HasColumnName("E_ID");

                entity.Property(e => e.EName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("E_Name");
            });

            modelBuilder.Entity<Privacy>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Privacy__A3420A77AE60A37A");

                entity.ToTable("Privacy");

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.PName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("P_Name");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.HasKey(e => e.QId)
                    .HasName("PK__Qualific__F4FC372E5910BF9E");

                entity.ToTable("Qualification");

                entity.Property(e => e.QId).HasColumnName("Q_ID");

                entity.Property(e => e.QName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Q_Name");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__Speciali__A3DFF16D2E9F8BDB");

                entity.ToTable("Specialization");

                entity.Property(e => e.SId).HasColumnName("S_ID");

                entity.Property(e => e.SName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("S_Name");
            });

            modelBuilder.Entity<UserReg>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__User_Reg__5A2040DB823CA47F");

                entity.ToTable("User_Reg");

                entity.Property(e => e.UId).HasColumnName("U_ID");

                entity.Property(e => e.UAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("U_Address");

                entity.Property(e => e.UContact)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("U_Contact");

                entity.Property(e => e.UEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("U_Email");

                entity.Property(e => e.UName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("U_Name");

                entity.Property(e => e.UPassword)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("U_Password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
