// <copyright file="ShoppingCart.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a shopping cart for a user.
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Gets or sets the unique identifier for the shopping cart.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with this shopping cart.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the shopping cart was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the collection of items in the shopping cart.
        /// </summary>
        [InverseProperty("Cart")]
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        /// <summary>
        /// Gets or sets the collection of orders associated with this shopping cart.
        /// </summary>
        [InverseProperty("ShoppingCart")]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        /// <summary>
        /// Gets or sets the user who owns this shopping cart.
        /// </summary>
        [ForeignKey("UserId")]
        [InverseProperty("ShoppingCarts")]
        required public User User { get; set; }
    }
}
