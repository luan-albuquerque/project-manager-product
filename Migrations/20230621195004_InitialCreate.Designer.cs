﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TesteVagaDevPleno.Infra;

#nullable disable

namespace TesteVagaDevPleno.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20230621195004_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TesteVagaDevPleno.Modules.ProductModule.Entity.Product", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("price_product")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
