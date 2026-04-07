// <copyright file="Product.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a product in the order management system.
    /// </summary>
    [Index("SKU", Name = "UQ_Products_SKU", IsUnique = true)]
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required]
        [StringLength(255)]
        required public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the stock keeping unit (SKU) identifier for the product.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        required public string SKU { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product available in stock.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the category identifier for this product.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the collection of cart items that reference this product.
        /// </summary>
        [InverseProperty("Product")]
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        /// <summary>
        /// Gets or sets the category that this product belongs to.
        /// </summary>
        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        required public virtual Category Category { get; set; }
    }
}
