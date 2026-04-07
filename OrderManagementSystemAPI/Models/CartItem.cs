// <copyright file="CartItem.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents an item in a shopping cart, linking a product to a cart with a quantity.
    /// </summary>
    [PrimaryKey("CartId", "ProductId")]
    public class CartItem
    {
        /// <summary>
        /// Gets or sets the shopping cart identifier. Part of the composite primary key.
        /// </summary>
        [Key]
        public int CartId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier. Part of the composite primary key.
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the cart.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart that contains this item.
        /// </summary>
        [ForeignKey("CartId")]
        [InverseProperty("CartItems")]
        required public ShoppingCart Cart { get; set; }

        /// <summary>
        /// Gets or sets the product that this cart item represents.
        /// </summary>
        [ForeignKey("ProductId")]
        [InverseProperty("CartItems")]
        required public Product Product { get; set; }
    }
}
