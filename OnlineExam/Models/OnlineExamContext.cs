﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineExam.Models
{
    public partial class OnlineExamContext : DbContext
    {
        public OnlineExamContext()
        {
        }

        public OnlineExamContext(DbContextOptions<OnlineExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=NEETHI-PC\\SQLEXPRESS;Database=OnlineExam;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Emailid)
                    .HasName("PK__admin__8734520A5D585728");

                entity.ToTable("admin");

                entity.Property(e => e.Emailid)
                    .HasColumnName("emailid")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("exam");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Minmarks).HasColumnName("minmarks");

                entity.Property(e => e.Subjectid).HasColumnName("subjectid");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.Subjectid)
                    .HasConstraintName("FK__exam__subjectid__6754599E");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.Questionid)
                    .HasName("PK__question__62C2216A198041D6");

                entity.ToTable("questions");

                entity.Property(e => e.Questionid).HasColumnName("questionid");

                entity.Property(e => e.Correctanswer)
                    .HasColumnName("correctanswer")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Option1)
                    .HasColumnName("option1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .HasColumnName("option2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .HasColumnName("option3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .HasColumnName("option4")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Subjectid).HasColumnName("subjectid");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Subjectid)
                    .HasConstraintName("FK__questions__subje__628FA481");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("result");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Marks).HasColumnName("marks");

                entity.Property(e => e.Subjectid).HasColumnName("subjectid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.Subjectid)
                    .HasConstraintName("FK__result__subjecti__656C112C");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__result__userid__6477ECF3");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.Subjectid)
                    .HasName("PK__subjects__ACE14378EC89DF09");

                entity.ToTable("subjects");

                entity.Property(e => e.Subjectid).HasColumnName("subjectid");

                entity.Property(e => e.Subjectname)
                    .HasColumnName("subjectname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__users__CBA1B25719623318");

                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasColumnName("qualification")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Yearofcompletion).HasColumnName("yearofcompletion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}