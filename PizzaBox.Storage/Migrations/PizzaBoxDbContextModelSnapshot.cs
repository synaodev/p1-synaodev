﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Migrations
{
    [DbContext(typeof(PizzaBoxDbContext))]
    partial class PizzaBoxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Property<long>("CrustID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("CrustID");

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            CrustID = 1L,
                            Name = "Deep Dish",
                            Price = 3.50m
                        },
                        new
                        {
                            CrustID = 2L,
                            Name = "New York Style",
                            Price = 2.50m
                        },
                        new
                        {
                            CrustID = 3L,
                            Name = "Thin Crust",
                            Price = 1.50m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("OrderID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("StoreID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("OrderID");

                    b.HasIndex("StoreID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderPizza", b =>
                {
                    b.Property<long>("PizzaID")
                        .HasColumnType("bigint");

                    b.Property<long>("OrderID")
                        .HasColumnType("bigint");

                    b.HasKey("PizzaID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.Property<long>("PizzaID")
                        .HasColumnType("bigint");

                    b.Property<long>("CrustID")
                        .HasColumnType("bigint");

                    b.Property<long>("SizeID")
                        .HasColumnType("bigint");

                    b.HasKey("PizzaID");

                    b.HasIndex("CrustID");

                    b.HasIndex("SizeID");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaID = 1L,
                            CrustID = 1L,
                            SizeID = 1L
                        },
                        new
                        {
                            PizzaID = 2L,
                            CrustID = 2L,
                            SizeID = 2L
                        },
                        new
                        {
                            PizzaID = 3L,
                            CrustID = 3L,
                            SizeID = 3L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaTopping", b =>
                {
                    b.Property<long>("PizzaID")
                        .HasColumnType("bigint");

                    b.Property<long>("ToppingID")
                        .HasColumnType("bigint");

                    b.HasKey("PizzaID", "ToppingID");

                    b.HasIndex("ToppingID");

                    b.ToTable("PizzaTopping");

                    b.HasData(
                        new
                        {
                            PizzaID = 1L,
                            ToppingID = 637205515438138710L
                        },
                        new
                        {
                            PizzaID = 1L,
                            ToppingID = 637205515438138974L
                        },
                        new
                        {
                            PizzaID = 1L,
                            ToppingID = 637205515438138987L
                        },
                        new
                        {
                            PizzaID = 2L,
                            ToppingID = 637205515438138710L
                        },
                        new
                        {
                            PizzaID = 2L,
                            ToppingID = 637205515438138974L
                        },
                        new
                        {
                            PizzaID = 2L,
                            ToppingID = 637205515438138990L
                        },
                        new
                        {
                            PizzaID = 3L,
                            ToppingID = 637205515438138710L
                        },
                        new
                        {
                            PizzaID = 3L,
                            ToppingID = 637205515438138974L
                        },
                        new
                        {
                            PizzaID = 3L,
                            ToppingID = 637205515438138992L
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("SizeID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("SizeID");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            SizeID = 1L,
                            Name = "Large",
                            Price = 12.00m
                        },
                        new
                        {
                            SizeID = 2L,
                            Name = "Medium",
                            Price = 10.00m
                        },
                        new
                        {
                            SizeID = 3L,
                            Name = "Small",
                            Price = 8.00m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Property<long>("StoreID")
                        .HasColumnType("bigint");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreID");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreID = 1L,
                            Location = "Albequerque",
                            Password = "Cadena",
                            Username = "EatAtJoe"
                        },
                        new
                        {
                            StoreID = 2L,
                            Location = "New York",
                            Password = "Benjamin",
                            Username = "MuggyPizza"
                        },
                        new
                        {
                            StoreID = 3L,
                            Location = "New Mexico",
                            Password = "Mario",
                            Username = "Whatever"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("ToppingID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ToppingID");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            ToppingID = 637205515438138710L,
                            Name = "Cheese",
                            Price = 0.25m
                        },
                        new
                        {
                            ToppingID = 637205515438138974L,
                            Name = "Tomato Sauce",
                            Price = 0.75m
                        },
                        new
                        {
                            ToppingID = 637205515438138987L,
                            Name = "Pepperoni",
                            Price = 0.50m
                        },
                        new
                        {
                            ToppingID = 637205515438138990L,
                            Name = "Bacon",
                            Price = 0.45m
                        },
                        new
                        {
                            ToppingID = 637205515438138992L,
                            Name = "Anchovies",
                            Price = 1.00m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1L,
                            Password = "Cadena",
                            Username = "Tyler"
                        },
                        new
                        {
                            UserID = 2L,
                            Password = "Benjamin",
                            Username = "Cody"
                        },
                        new
                        {
                            UserID = 3L,
                            Password = "Mario",
                            Username = "Mario"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.OrderPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Order", "Order")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Pizza", "Pizza")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("PizzaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany("Pizzas")
                        .HasForeignKey("CrustID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PizzaTopping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Topping", "Topping")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("ToppingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
