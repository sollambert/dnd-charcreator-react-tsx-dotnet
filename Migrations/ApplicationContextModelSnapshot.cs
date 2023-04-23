﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dnd_weekend_project.Models;

#nullable disable

namespace dnd_weekend_project.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("dnd_weekend_project.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte>("Charisma")
                        .HasColumnType("smallint");

                    b.Property<byte>("Constitution")
                        .HasColumnType("smallint");

                    b.Property<byte>("Dexterity")
                        .HasColumnType("smallint");

                    b.Property<byte>("Intelligence")
                        .HasColumnType("smallint");

                    b.Property<byte>("Level")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Profession")
                        .HasColumnType("integer");

                    b.Property<int>("Race")
                        .HasColumnType("integer");

                    b.Property<byte>("Strength")
                        .HasColumnType("smallint");

                    b.Property<byte>("Wisdom")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("ChatGPTRequests");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("created")
                        .HasColumnType("integer");

                    b.Property<string>("gptId")
                        .HasColumnType("text");

                    b.Property<string>("model")
                        .HasColumnType("text");

                    b.Property<string>("object")
                        .HasColumnType("text");

                    b.Property<int?>("usageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("usageId");

                    b.ToTable("ChatGPTResponses");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse+Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ChatGPTResponseId")
                        .HasColumnType("integer");

                    b.Property<string>("finish_reason")
                        .HasColumnType("text");

                    b.Property<int>("index")
                        .HasColumnType("integer");

                    b.Property<int?>("messageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ChatGPTResponseId");

                    b.HasIndex("messageId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse+Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("content")
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse+Usage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("completion_tokens")
                        .HasColumnType("integer");

                    b.Property<int>("prompt_tokens")
                        .HasColumnType("integer");

                    b.Property<int>("total_tokens")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Usage");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse", b =>
                {
                    b.HasOne("dnd_weekend_project.Models.ChatGPTResponse+Usage", "usage")
                        .WithMany()
                        .HasForeignKey("usageId");

                    b.Navigation("usage");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse+Choice", b =>
                {
                    b.HasOne("dnd_weekend_project.Models.ChatGPTResponse", null)
                        .WithMany("choices")
                        .HasForeignKey("ChatGPTResponseId");

                    b.HasOne("dnd_weekend_project.Models.ChatGPTResponse+Message", "message")
                        .WithMany()
                        .HasForeignKey("messageId");

                    b.Navigation("message");
                });

            modelBuilder.Entity("dnd_weekend_project.Models.ChatGPTResponse", b =>
                {
                    b.Navigation("choices");
                });
#pragma warning restore 612, 618
        }
    }
}
