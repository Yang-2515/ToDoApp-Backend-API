using System;
using ApplicationTier.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoApp.Domain.Entities;

#nullable disable

namespace ToDoApp.Infrastructure
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Attackment> Attackments { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<BoardMember> BoardMembers { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<ListTask> ListTasks { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskLabel> TaskLabels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VwLabel> VwLabels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_task");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usertask");
            });

            modelBuilder.Entity<Attackment>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Attackments)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_taskattachment");
            });

            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasOne(d => d.Manage)
                    .WithMany(p => p.Boards)
                    .HasForeignKey(d => d.ManageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_manageboard");
            });

            modelBuilder.Entity<BoardMember>(entity =>
            {
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.BoardMembers)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_board");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BoardMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_user");
            });

            modelBuilder.Entity<ListTask>(entity =>
            {
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.ListTasks)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("fk_id_boardlisttask");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasOne(d => d.ListTask)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ListTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_listtask");
            });

            modelBuilder.Entity<TaskLabel>(entity =>
            {
                entity.HasOne(d => d.Label)
                    .WithMany(p => p.TaskLabels)
                    .HasForeignKey(d => d.LabelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_labeltask");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskLabels)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tasklabel");
            });

            modelBuilder.Entity<VwLabel>(entity =>
            {
                entity.ToView("vwLabels");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
