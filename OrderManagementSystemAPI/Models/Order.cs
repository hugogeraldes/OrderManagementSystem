// <copyright file="Order.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents an order placed by a user.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart identifier associated with this order.
        /// </summary>
        public int ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or sets the total price of the order.
        /// </summary>
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the current status of the order.
        /// </summary>
        [Required]
        [StringLength(9)]
        [Unicode(false)]
        required public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the order was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart associated with this order.
        /// </summary>
        [ForeignKey("ShoppingCartId")]
        [InverseProperty("Orders")]
        required public ShoppingCart ShoppingCart { get; set; }
    }
}
