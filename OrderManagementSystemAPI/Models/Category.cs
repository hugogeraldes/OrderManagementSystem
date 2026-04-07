// <copyright file="Category.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a product category in the order management system.
    /// </summary>
    [Index("Name", Name = "UQ_Category_Name", IsUnique = true)]
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [Required]
        [StringLength(255)]
        required public string Name { get; set; }

        /// <summary>
        /// Gets the collection of products that belong to this category.
        /// </summary>
        [InverseProperty("Category")]
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
