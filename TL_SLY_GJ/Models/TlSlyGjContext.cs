using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TL_SLY_GJ.Models;

public partial class TlSlyGjContext : DbContext
{
    public TlSlyGjContext()
    {
    }

    public TlSlyGjContext(DbContextOptions<TlSlyGjContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("question");

            entity.HasIndex(e => e.QuizId, "question_fk1_idx");

            entity.Property(e => e.QuestionId)
                .ValueGeneratedNever()
                .HasColumnName("question_id");
            entity.Property(e => e.Answer1)
                .HasMaxLength(45)
                .HasColumnName("answer_1");
            entity.Property(e => e.Answer2)
                .HasMaxLength(45)
                .HasColumnName("answer_2");
            entity.Property(e => e.Answer3)
                .HasMaxLength(45)
                .HasColumnName("answer_3");
            entity.Property(e => e.Answer4)
                .HasMaxLength(45)
                .HasColumnName("answer_4");
            entity.Property(e => e.Correct).HasColumnName("correct");
            entity.Property(e => e.QuestionText)
                .HasMaxLength(45)
                .HasColumnName("question_text");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("question_fk1");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PRIMARY");

            entity.ToTable("quiz");

            entity.HasIndex(e => e.UserId, "quiz_fk1_idx");

            entity.HasIndex(e => e.SubjectId, "quiz_fk2_idx");

            entity.Property(e => e.QuizId)
                .ValueGeneratedNever()
                .HasColumnName("quiz_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quiz_fk2");

            entity.HasOne(d => d.User).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quiz_fk1");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subject_id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
