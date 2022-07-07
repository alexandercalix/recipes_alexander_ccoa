﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using recipes_alexander_ccoa.Core.Models;

namespace recipes_alexander_ccoa.Core.Data
{
    public partial class recipesContext : DbContext
    {
        public recipesContext()
        {
        }

        public recipesContext(DbContextOptions<recipesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Motores> Motores { get; set; }
        public virtual DbSet<Recetas> Recetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=recipes_alexander_ccoa;Persist Security Info=True;User ID=sa;Password=Magdalena1995");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motores>(entity =>
            {
                entity.ToTable("MOTORES");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NoMotor)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recetas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cant1).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant2).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant3).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant4).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant5).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant6).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant7).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Cant8).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InsT1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT3)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT4)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT5)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT6)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT7)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsT8)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mezcla)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}