﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Models;

namespace WebApplication4.Migrations
{
    [DbContext(typeof(AllContext))]
    [Migration("20200928034943_removeUnique")]
    partial class removeUnique
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication4.Models.Readership", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("lastAccessTime");

                    b.Property<int>("reportId");

                    b.Property<int>("userId");

                    b.Property<int>("view");

                    b.HasKey("id");

                    b.HasIndex("reportId")
                        .IsUnique();

                    b.HasIndex("userId")
                        .IsUnique();

                    b.ToTable("Readerships");
                });

            modelBuilder.Entity("WebApplication4.Models.Report", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("DataFiles");

                    b.Property<string>("title");

                    b.Property<DateTime>("uploadedTime");

                    b.Property<int>("uploaderId");

                    b.HasKey("id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("WebApplication4.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("password");

                    b.Property<int?>("reportid");

                    b.Property<string>("role");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.HasIndex("reportid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication4.Models.Readership", b =>
                {
                    b.HasOne("WebApplication4.Models.Report", "report")
                        .WithOne("readership")
                        .HasForeignKey("WebApplication4.Models.Readership", "reportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication4.Models.User", "User")
                        .WithOne("readership")
                        .HasForeignKey("WebApplication4.Models.Readership", "userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication4.Models.User", b =>
                {
                    b.HasOne("WebApplication4.Models.Report", "report")
                        .WithMany()
                        .HasForeignKey("reportid");
                });
#pragma warning restore 612, 618
        }
    }
}
