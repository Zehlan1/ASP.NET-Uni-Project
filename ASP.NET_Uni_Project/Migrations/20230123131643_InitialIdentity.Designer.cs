﻿// <auto-generated />
using System;
using ASP.NET_Uni_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NETUniProject.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20230123131643_InitialIdentity")]
    partial class InitialIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            ConcurrencyStamp = "dc683997-3426-4f1e-9ef6-167be38bfdb2",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            ConcurrencyStamp = "bceca40e-6ec8-4d16-bad7-04c2050502c7",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "90f50695-2d66-47bf-ac04-820ee7dc807d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "65a6dc9c-62b8-453d-82e5-8cca2d60bc0b",
                            Email = "admin1@fake.fake",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN1@FAKE.FAKE",
                            NormalizedUserName = "ADMIN1@FAKE.FAKE",
                            PasswordHash = "AQAAAAEAACcQAAAAEH58QBwrBJrPMcWCjbjOfC6ZlF/kQkzHtqLi4gSVkwVIyMPW+2vRmzgwG2UjnD7yRw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fdc3a73a-ab1a-48f1-bbc6-2badecf084b3",
                            TwoFactorEnabled = false,
                            UserName = "admin1@fake.fake"
                        },
                        new
                        {
                            Id = "023d586c-fdba-4fab-8196-90685b128664",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eabd687e-3744-40f3-a513-35b7074f3097",
                            Email = "test1@fake.fake",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST1@FAKE.FAKE",
                            NormalizedUserName = "TEST1@FAKE.FAKE",
                            PasswordHash = "AQAAAAEAACcQAAAAEILcjt9IZg9oBFSkmhnjtT/sY+PK/BumF0T4nLeTkLG7u4YMBE/WilN/iN5ur5VD6A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "46e0fb84-8a28-433b-a856-b3ac1bc924a6",
                            TwoFactorEnabled = false,
                            UserName = "test1@fake.fake"
                        },
                        new
                        {
                            Id = "e8d37b64-c354-41bd-ac1d-93e8e73b1b8f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "63cb5bf5-b96e-48e4-ba4d-b314d358e676",
                            Email = "test2@fake.fake",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST2@FAKE.FAKE",
                            NormalizedUserName = "TEST2@FAKE.FAKE",
                            PasswordHash = "AQAAAAEAACcQAAAAEMhbzbFxdU16IVnrWHkPYkmlJgnTFti+nNQLKUF9QXNpchF2FfaIbH0G82q9Q2yFdQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "61f10ef0-5655-4621-aa48-691048c1e7df",
                            TwoFactorEnabled = false,
                            UserName = "test2@fake.fake"
                        },
                        new
                        {
                            Id = "6da4ec6e-fc74-4846-96b6-68049794e89d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4f9ed0d4-2810-4022-b2fc-09a274e0d1e1",
                            Email = "test3@fake.fake",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST3@FAKE.FAKE",
                            NormalizedUserName = "TEST3@FAKE.FAKE",
                            PasswordHash = "AQAAAAEAACcQAAAAEDRiFJmyfssH+hoCV3ChEAktUcqRPa8iLXylBiWlVohWfSRcZx6KKy1yz4ypv3cjnA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "46a3d956-f96d-4c61-8d79-198a80d4e25d",
                            TwoFactorEnabled = false,
                            UserName = "test3@fake.fake"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "90f50695-2d66-47bf-ac04-820ee7dc807d",
                            RoleId = "1"
                        },
                        new
                        {
                            UserId = "023d586c-fdba-4fab-8196-90685b128664",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "e8d37b64-c354-41bd-ac1d-93e8e73b1b8f",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "6da4ec6e-fc74-4846-96b6-68049794e89d",
                            RoleId = "2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}