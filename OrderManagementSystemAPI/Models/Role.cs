// <copyright file="Role.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a user role in the order management system.
    /// </summary>
    [Index("Name", Name = "UQ__RoleName", IsUnique = true)]
    public class Role
    {
        /// <summary>
        /// Gets or sets the unique identifier for the role.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        [Required]
        [StringLength(255)]
        required public string Name { get; set; }

        /// <summary>
        /// Gets the collection of Users associated with this role.
        /// </summary>
        [InverseProperty("Roles")]
        public ICollection<User> Users { get; } = new List<User>();
    }
}
