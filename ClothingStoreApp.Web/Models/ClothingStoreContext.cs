using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClothingStoreApp.Web.Models
{
    public partial class ClothingStoreContext : DbContext
    {
        public ClothingStoreContext(DbContextOptions<ClothingStoreContext> options) : base(options)

        {

        }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderNumber> OrderNumber { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ClothingStore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Address_CustomerId");

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_Address_OrderId");

                entity.Property(e => e.AddressLine1).IsRequired();

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.State).IsRequired();

                entity.Property(e => e.ZipCode).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Order_CustomerId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderItem_OrderId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_OrderItem_ProductId");

                entity.Property(e => e.Price).HasColumnType("decimal");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OrderItem_Product");
            });

            modelBuilder.Entity<OrderNumber>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderNumber_OrderId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderNumber)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductImage_ProductId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImage)
                    .HasForeignKey(d => d.ProductId);
            });
        }
    }
}