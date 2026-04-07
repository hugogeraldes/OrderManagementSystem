// <copyright file="AppDbContext.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using OrderManagementSystemAPI.Models;

    /// <summary>
    /// Represents the application database context for the Order Management System.
    /// </summary>
    public partial class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for cart items.
        /// </summary>
        public virtual DbSet<CartItem> CartItems { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for categories.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for orders.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for products.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for roles.
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for shopping carts.
        /// </summary>
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for users.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.CartId, e.ProductId }).HasName("PK_CartItems");

                entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItems_CartID");

                entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItems_ProductId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Categoty");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Orders");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.ShoppingCart).WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_CartId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Products");

                entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_CategoryId");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Roles");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ShoppingCarts");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.User).WithMany(p => p.ShoppingCarts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCart_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Users");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        r => r.HasOne<Role>().WithMany()
                            .HasForeignKey("RoleId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_UserRoles_RoleId"),
                        l => l.HasOne<User>().WithMany()
                            .HasForeignKey("UserId")
                            .OnDelete(DeleteBehavior.ClientCascade)
                            .HasConstraintName("FK_UserRoles_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_UserRoles");
                            j.ToTable("UserRoles");
                        });
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// Partial method for additional model configuration.
        /// </summary>
        /// <param name="modelBuilder">The model builder being used to construct the model for this context.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
