﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StartSch.Data;

#nullable disable

namespace StartSch.Data.Migrations.Postgres
{
    [DbContext(typeof(PostgresDb))]
    partial class PostgresDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventGroup", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.HasKey("EventsId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("EventGroup");
                });

            modelBuilder.Entity("GroupPost", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.HasKey("GroupsId", "PostsId");

                    b.HasIndex("PostsId");

                    b.ToTable("GroupPost");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("StartSch.Data.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<DateTime?>("EndUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Events");

                    b.HasDiscriminator().HasValue("Event");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("StartSch.Data.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PekId")
                        .HasColumnType("integer");

                    b.Property<string>("PekName")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("PincerName")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.HasIndex("PekId")
                        .IsUnique();

                    b.HasIndex("PincerName")
                        .IsUnique();

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StartSch.Data.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentMarkdown")
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ExcerptMarkdown")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime?>("PublishedUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("character varying(130)");

                    b.Property<string>("Url")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("StartSch.Data.PushSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Auth")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("P256DH")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Endpoint")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("PushSubscriptions");
                });

            modelBuilder.Entity("StartSch.Data.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("StartSch.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StartSch.Data.UserTagSelection", b =>
                {
                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("TagId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTagSelections");
                });

            modelBuilder.Entity("StartSch.Data.Opening", b =>
                {
                    b.HasBaseType("StartSch.Data.Event");

                    b.Property<DateTime?>("OrderingEndUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("OrderingStartUtc")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue("Opening");
                });

            modelBuilder.Entity("EventGroup", b =>
                {
                    b.HasOne("StartSch.Data.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartSch.Data.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupPost", b =>
                {
                    b.HasOne("StartSch.Data.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartSch.Data.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartSch.Data.Event", b =>
                {
                    b.HasOne("StartSch.Data.Event", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("StartSch.Data.Post", b =>
                {
                    b.HasOne("StartSch.Data.Event", "Event")
                        .WithMany("Posts")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("StartSch.Data.PushSubscription", b =>
                {
                    b.HasOne("StartSch.Data.User", "User")
                        .WithMany("PushSubscriptions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StartSch.Data.UserTagSelection", b =>
                {
                    b.HasOne("StartSch.Data.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartSch.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StartSch.Data.Event", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("StartSch.Data.User", b =>
                {
                    b.Navigation("PushSubscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
