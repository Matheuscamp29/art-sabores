﻿// <auto-generated />
using System;
using Art_Sabores.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Art_Sabores.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250611211832_BancoConcluidoFinal")]
    partial class BancoConcluidoFinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Art_Sabores.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Art_Sabores.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Art_Sabores.Models.ItemMateriaPrima", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdMateriaPrima")
                        .HasColumnType("int");

                    b.Property<int>("IdPedidoFornecedor")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaPrimaId")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoFornecedorId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MateriaPrimaId");

                    b.HasIndex("PedidoFornecedorId");

                    b.ToTable("ItemsMateriaPrima");
                });

            modelBuilder.Entity("Art_Sabores.Models.ItemSalgado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPedidoCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdSalgado")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPedidoCliente");

                    b.HasIndex("IdSalgado");

                    b.ToTable("ItemSalgados");
                });

            modelBuilder.Entity("Art_Sabores.Models.MateriaPrima", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MateriaPrimas");
                });

            modelBuilder.Entity("Art_Sabores.Models.NotaFiscalCliente", b =>
                {
                    b.Property<string>("NFE")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdPedidoCliente")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("NFE");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PedidoClienteId");

                    b.ToTable("Vendas_Clientes_Receita");
                });

            modelBuilder.Entity("Art_Sabores.Models.NotaFiscalFornecedor", b =>
                {
                    b.Property<string>("NFE")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoFornecedorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("NFE");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("PedidoFornecedorId");

                    b.ToTable("Vendas_Fornecedores_MateriaPrima");
                });

            modelBuilder.Entity("Art_Sabores.Models.PedidoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PedidosCliente");
                });

            modelBuilder.Entity("Art_Sabores.Models.PedidoFornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PedidoFornecedores");
                });

            modelBuilder.Entity("Art_Sabores.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("FlagConstante")
                        .HasColumnType("bit");

                    b.Property<int>("IdMateriaPrima")
                        .HasColumnType("int");

                    b.Property<int>("IdSalgado")
                        .HasColumnType("int");

                    b.Property<int?>("MateriaPrimaId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeMatPrim")
                        .HasColumnType("int");

                    b.Property<int>("Rendimento")
                        .HasColumnType("int");

                    b.Property<int?>("SalgadoId")
                        .HasColumnType("int");

                    b.Property<string>("unidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MateriaPrimaId");

                    b.HasIndex("SalgadoId");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("Art_Sabores.Models.Salgado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Salgados");
                });

            modelBuilder.Entity("Art_Sabores.Models.ItemMateriaPrima", b =>
                {
                    b.HasOne("Art_Sabores.Models.MateriaPrima", "MateriaPrima")
                        .WithMany()
                        .HasForeignKey("MateriaPrimaId");

                    b.HasOne("Art_Sabores.Models.PedidoFornecedor", "PedidoFornecedor")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoFornecedorId");

                    b.Navigation("MateriaPrima");

                    b.Navigation("PedidoFornecedor");
                });

            modelBuilder.Entity("Art_Sabores.Models.ItemSalgado", b =>
                {
                    b.HasOne("Art_Sabores.Models.PedidoCliente", "PedidoCliente")
                        .WithMany("Itens")
                        .HasForeignKey("IdPedidoCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Art_Sabores.Models.Salgado", "Salgado")
                        .WithMany()
                        .HasForeignKey("IdSalgado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PedidoCliente");

                    b.Navigation("Salgado");
                });

            modelBuilder.Entity("Art_Sabores.Models.NotaFiscalCliente", b =>
                {
                    b.HasOne("Art_Sabores.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Art_Sabores.Models.PedidoCliente", "PedidoCliente")
                        .WithMany()
                        .HasForeignKey("PedidoClienteId");

                    b.Navigation("Cliente");

                    b.Navigation("PedidoCliente");
                });

            modelBuilder.Entity("Art_Sabores.Models.NotaFiscalFornecedor", b =>
                {
                    b.HasOne("Art_Sabores.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.HasOne("Art_Sabores.Models.PedidoFornecedor", "PedidoFornecedor")
                        .WithMany()
                        .HasForeignKey("PedidoFornecedorId");

                    b.Navigation("Fornecedor");

                    b.Navigation("PedidoFornecedor");
                });

            modelBuilder.Entity("Art_Sabores.Models.Receita", b =>
                {
                    b.HasOne("Art_Sabores.Models.MateriaPrima", "MateriaPrima")
                        .WithMany()
                        .HasForeignKey("MateriaPrimaId");

                    b.HasOne("Art_Sabores.Models.Salgado", "Salgado")
                        .WithMany()
                        .HasForeignKey("SalgadoId");

                    b.Navigation("MateriaPrima");

                    b.Navigation("Salgado");
                });

            modelBuilder.Entity("Art_Sabores.Models.PedidoCliente", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("Art_Sabores.Models.PedidoFornecedor", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
