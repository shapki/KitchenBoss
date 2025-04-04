namespace KitchenBoss.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        public Guid PasswordSalt { get; set; }

        public int PositionID { get; set; }

        public int? EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Position Position { get; set; }
    }
}
