// <copyright file="User.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a user in the order management system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Required]
        [StringLength(255)]
        required public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [Required]
        [StringLength(255)]
        required public string Email { get; set; }

        /// <summary>
        /// Gets or sets the hashed password for authentication.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        required public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user account was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the collection of shopping carts associated with this user.
        /// </summary>
        [InverseProperty("User")]
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

        /// <summary>
        /// Gets or sets the collection of roles assigned to this user.
        /// </summary>
        [InverseProperty("Users")]
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
