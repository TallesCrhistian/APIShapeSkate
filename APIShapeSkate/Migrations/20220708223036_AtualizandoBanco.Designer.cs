﻿// <auto-generated />
using APIShapeSkate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIShapeSkate.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220708223036_AtualizandoBanco")]
    partial class AtualizandoBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("APIShapeSkate.Data.Shape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Madeira")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Shapes");
                });
#pragma warning restore 612, 618
        }
    }
}
