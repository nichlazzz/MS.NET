using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Restoraunt.Restoraunt.DataAccess;


namespace Restoraunt.DataAccess.Migrations
{
    [DbContext(typeof(RestorauntDbContext))]
    [Migration("20231030081930_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            // Связь между User и Order
            modelBuilder.Entity("UserOrderEntity", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("UserOrders", (string)null);
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");
                    

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            // Связь между User и Order
            modelBuilder.Entity("UserOrderEntity", b =>
                {
                    b.HasOne("YourNamespace.DataAccess.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YourNamespace.DataAccess.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            // Связь между Order и User
            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Order", b =>
                {
                    b.HasOne("YourNamespace.DataAccess.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            // Связь между Product и Category
            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("YourNamespace.DataAccess.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            // Связь между Payment и Order
            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Payment", b =>
                {
                    b.HasOne("YourNamespace.DataAccess.Entities.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("YourNamespace.DataAccess.Entities.Order", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}